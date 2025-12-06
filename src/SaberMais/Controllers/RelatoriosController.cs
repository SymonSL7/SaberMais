using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;

namespace SaberMais.Controllers
{
    [Authorize(Roles = "Instrutor")]
    public class RelatoriosController : Controller
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        private bool TentarObterInstrutorId(out int instrutorId)
        {
            instrutorId = 0;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId != null && int.TryParse(userId, out instrutorId);
        }

        public async Task<IActionResult> Index()
        {
            if (!TentarObterInstrutorId(out int idUsuario))
                return RedirectToAction("Login", "Usuarios");

            ViewBag.Cursos = await _context.Cursos
                .AsNoTracking()
                .Where(c => c.UsuarioId == idUsuario)
                .ToListAsync();

            return View();
        }

        public async Task<IActionResult> ProgressoUsuarios(int? cursoId)
        {
            if (!TentarObterInstrutorId(out int idUsuario))
                return RedirectToAction("Login", "Usuarios");

            var cursosComDados = await _context.Cursos
                .AsNoTracking()
                .Where(c => c.UsuarioId == idUsuario && (!cursoId.HasValue || c.Id == cursoId))
                .Include(c => c.Aulas)
                .Include(c => c.Matriculas)
                    .ThenInclude(m => m.Usuario)
                .Include(c => c.Matriculas)
                    .ThenInclude(m => m.AulasConcluidas)
                .AsSplitQuery()
                .ToListAsync();

            var relatorioProgresso = cursosComDados
                .SelectMany(curso =>
                {
                    var aulasAtivas = curso.Aulas.Count(a => a.Status == Status.Ativo);

                    return curso.Matriculas.Select(matricula =>
                    {
                        var aulasConcluidas = matricula.AulasConcluidas.Count(ac => ac.Concluida);
                        return new RelatorioProgressoViewModel
                        {
                            CursoId = curso.Id,
                            CursoTitulo = curso.Titulo,
                            UsuarioId = matricula.UsuarioId,
                            UsuarioNome = matricula.Usuario.Nome,
                            UsuarioEmail = matricula.Usuario.Email,
                            TotalAulasAtivas = aulasAtivas,
                            AulasConcluidas = aulasConcluidas,
                            PercentualConclusao = aulasAtivas > 0
                                ? Math.Round((double)aulasConcluidas / aulasAtivas * 100, 2)
                                : 0,
                            DataMatricula = matricula.DataMatricula
                        };
                    });
                })
                .ToList();

            ViewBag.Cursos = await _context.Cursos
                .AsNoTracking()
                .Where(c => c.UsuarioId == idUsuario)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Titulo
                })
                .ToListAsync();

            ViewBag.CursoSelecionado = cursoId;

            return View(relatorioProgresso);
        }

        public async Task<IActionResult> PerguntasSemRespostas(int? cursoId)
        {
            if (!TentarObterInstrutorId(out int idUsuario))
                return RedirectToAction("Login", "Usuarios");

            var perguntasSemRespostas = await _context.Perguntas
                .AsNoTracking()
                .Include(p => p.Aula)
                    .ThenInclude(a => a.Curso)
                .Include(p => p.Usuario)
                .Where(p => p.Aula.Curso.UsuarioId == idUsuario)
                .Where(p => !p.Respostas.Any())
                .Where(p => !cursoId.HasValue || p.Aula.CursoId == cursoId)
                .Select(p => new RelatorioPerguntasSemRespostaViewModel
                {
                    PerguntaId = p.Id,
                    PerguntaConteudo = p.Conteudo,
                    DataPergunta = p.Data,
                    AulaId = p.AulaId,
                    AulaTitulo = p.Aula.Titulo,
                    CursoId = p.Aula.CursoId,
                    CursoTitulo = p.Aula.Curso.Titulo,
                    UsuarioNome = p.Usuario.Nome,
                    UsuarioEmail = p.Usuario.Email
                })
                .ToListAsync();

            ViewBag.Cursos = await _context.Cursos
                .AsNoTracking()
                .Where(c => c.UsuarioId == idUsuario)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Titulo
                })
                .ToListAsync();

            ViewBag.CursoSelecionado = cursoId;

            return View(perguntasSemRespostas);
        }
    }
}