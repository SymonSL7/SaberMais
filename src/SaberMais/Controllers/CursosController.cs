using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace SaberMais.Controllers
{
    [Authorize]
    public class CursosController : Controller
    {
        private readonly AppDbContext _context;
        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Cursos.Where(c => c.Status == Status.Ativo).OrderByDescending(c => c.QtdInscritos).Take(6).ToListAsync();
            return View(dados);
        }

        public async Task<IActionResult> CursosDisponiveis(int page = 1, string termo = "")
        {
            int pageSize = 9;

            var query = _context.Cursos
                .Where(c => c.Status == Status.Ativo);

            query = AplicarFiltroDeTermo(query, termo);

            query = query.OrderBy(c => c.Titulo);

            var pagedData = await query.ToPagedListAsync(page, pageSize);

            ViewBag.Termo = termo;
            return View(pagedData);
        }

        [Authorize]
        public async Task<IActionResult> MinhasInscricoes(int page = 1, string termo = "")
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int usuarioID = int.Parse(userIdString);
            
            int pageSize = 9;

            var query = _context.Cursos.Where(c => c.Status == Status.Ativo)
            .Where(c => _context.Matriculas.Any(m => m.UsuarioId == usuarioID && m.CursoId == c.Id && m.Situacao == true));

            query = AplicarFiltroDeTermo(query, termo);

            query = query.OrderBy(c => c.Titulo);

            var pagedData = await query.ToPagedListAsync(page, pageSize);

            ViewBag.Termo = termo;
            return View(pagedData);
        }

        [Authorize(Roles = "Instrutor")]
        public async Task<IActionResult> Gerenciar(int page = 1, string termo = "")
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int idUsuario = int.Parse(userId);

            int pageSize = 6;

            var query = _context.Cursos.Where(c => c.UsuarioId == idUsuario);

            query = AplicarFiltroDeTermo(query, termo);

            query = query.OrderBy(c => c.Titulo);

            var pagedData = await query.ToPagedListAsync(page, pageSize);

            ViewBag.Termo = termo;

            return View(pagedData);
        }

        [Authorize(Roles = "Instrutor")]
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        [Authorize(Roles = "Instrutor")]
        [HttpPost]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                curso.UsuarioId = userId;
                curso.Status = Status.Inativo;

                _context.Cursos.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction("Gerenciar");
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", curso.UsuarioId);
            return View(curso);
        }

        [Authorize(Roles = "Instrutor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cursos.FindAsync(id);
            if (dados == null)
                return NotFound();

            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (dados.UsuarioId != currentUserId)

                return RedirectToAction("CursosDisponiveis");

            return View(dados);
        }

        [Authorize(Roles = "Instrutor")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Curso curso)
        {
            if (id != curso.Id)
                return NotFound();

            var cursoExistente = await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (cursoExistente == null)
            {
                return NotFound();
            }

            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (cursoExistente.UsuarioId != currentUserId)

                return RedirectToAction("CursosDisponiveis");

            if (ModelState.IsValid)
            {
                curso.UsuarioId = cursoExistente.UsuarioId;

                _context.Cursos.Update(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction("Gerenciar");
            }
            return View(curso);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
                return NotFound();

            var dados = await _context.Cursos.FindAsync(id);

            if (dados == null)
                return NotFound();

            ViewBag.IsCreator = false;
            ViewBag.IsEnrolled = false;

            string? userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);

                if (dados.UsuarioId == userId)
                {
                    ViewBag.IsCreator = true;
                }
                else
                {
                    ViewBag.IsEnrolled = await _context.Matriculas
                        .AnyAsync(m => m.UsuarioId == userId && m.CursoId == id && m.Situacao == true);
                }
            }

            return View(dados);

        }

        [Authorize(Roles = "Instrutor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cursos.FindAsync(id);

            if (dados == null)
                return NotFound();
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (dados.UsuarioId != currentUserId)
                return RedirectToAction("CursosDisponiveis");

            return View(dados);

        }

        [Authorize(Roles = "Instrutor")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var curso = await _context.Cursos
                .Include(c => c.Matriculas)
                    .ThenInclude(m => m.AulasConcluidas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (curso == null)
                return NotFound();

            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (curso.UsuarioId != currentUserId)
                return RedirectToAction("CursosDisponiveis");

            foreach (var matricula in curso.Matriculas)
            {
                _context.AulaConcluidas.RemoveRange(matricula.AulasConcluidas);
            }
            _context.Matriculas.RemoveRange(curso.Matriculas);

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return RedirectToAction("Gerenciar");

        }

        private IQueryable<Curso> AplicarFiltroDeTermo(IQueryable<Curso> query, string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return query;
            }

            var termoLower = termo.ToLower();

            return query.Where(c =>
                c.Titulo.ToLower().Contains(termoLower) ||
                c.Descricao.ToLower().Contains(termoLower)
            );
        }
    }
}
