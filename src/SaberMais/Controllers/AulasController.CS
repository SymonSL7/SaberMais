using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;

namespace SaberMais.Controllers
{
    [Authorize]
    public class AulasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AulasController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AulasController(AppDbContext context, ILogger<AulasController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int? cursoId)
        {
            
            if (!cursoId.HasValue)
            {
                return RedirectToAction("Index", "Cursos");
            }

            var curso = await _context.Cursos
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(c => c.Id == cursoId.Value);

            if (curso == null)
            {
                _logger.LogWarning($"Tentativa de acessar aulas de um curso inexistente: {cursoId.Value}");
                return RedirectToAction("Index", "Cursos");
            }

            ViewData["NomeCurso"] = curso.Titulo;

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isCreator = false;
            if (userIdString != null)
            {
                isCreator = (curso.UsuarioId.ToString() == userIdString);
            }

            var query = _context.Aulas
                .Include(a => a.Curso)
                .Where(a => a.CursoId == cursoId.Value);

            if (!isCreator)
            {
                query = query.Where(a => a.Status == Status.Ativo);
            }


            ViewData["CursoId"] = cursoId.Value;
            ViewData["IsCreator"] = isCreator;
            
            return View(await query.ToListAsync());
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            
                if (id == null)
                {
                    return NotFound();
                }


                var aula = await _context.Aulas
                    .Include(a => a.Curso)
                    .Include(a => a.Perguntas.OrderByDescending(p => p.Data))
                        .ThenInclude(p => p.Usuario)
                    .Include(a => a.Perguntas)
                        .ThenInclude(p => p.Respostas.OrderBy(r => r.Data))
                            .ThenInclude(r => r.Usuario)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (aula == null)
                {
                    return NotFound();
                }

                
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userIdString == null)
                {
                    return Challenge();
                }
                var userId = int.Parse(userIdString);
                bool isCreator = (aula.Curso.UsuarioId == userId);
                ViewData["IsCreator"] = isCreator; 

                bool isEnrolled = false;
                if (!isCreator)
                {
                    isEnrolled = await _context.Matriculas
                        .AnyAsync(m => m.CursoId == aula.CursoId && m.UsuarioId == userId);
                }
                if (!isCreator && !isEnrolled)
                {
                    TempData["MensagemAviso"] =  "Se inscreva no curso para poder ver as aulas.";
                    return RedirectToAction("Details", "Cursos", new {id = aula.CursoId});
                }

                bool foiConcluida = false;

                if (!isCreator)
                {
                    var matricula = await _context.Matriculas
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.CursoId == aula.CursoId && m.UsuarioId == userId);
                    
                    if (matricula != null)
                    {
                        foiConcluida = await _context.AulaConcluidas
                            .AnyAsync(ac => ac.AulaId == aula.Id && ac.MatriculaId == matricula.Id);
                    }
                }
                
                ViewData["FoiConcluida"] = foiConcluida;

                var aulasQueryBase = _context.Aulas.Where(a => a.CursoId == aula.CursoId);
                IQueryable<Aula> orderedAulasQuery;
                if (!isCreator)
                {
                    orderedAulasQuery = aulasQueryBase.Where(a => a.Status == Status.Ativo).OrderBy(a => a.Id);
                }
                else
                {
                    orderedAulasQuery = aulasQueryBase.OrderBy(a => a.Id);
                }
                var todasAulasDoCurso = await orderedAulasQuery.ToListAsync();
                ViewData["MenuAulas"] = todasAulasDoCurso; 
                
                int currentIndex = todasAulasDoCurso.FindIndex(a => a.Id == aula.Id);
                int? previousAulaId = (currentIndex > 0) ? todasAulasDoCurso[currentIndex - 1].Id : (int?)null;
                int? nextAulaId = (currentIndex >= 0 && currentIndex < todasAulasDoCurso.Count - 1) ? todasAulasDoCurso[currentIndex + 1].Id : (int?)null;
                
                ViewData["PreviousAulaId"] = previousAulaId;
                ViewData["NextAulaId"] = nextAulaId;

                return View(aula);

        }

        public async Task<IActionResult> Create(int? cursoId)
        {
            
            var idUsuarioLogado = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (cursoId == null)
            {

                return RedirectToAction("Index", "Cursos"); 

            }

            var donoDoCursoId = await _context.Cursos
                                    .AsNoTracking()
                                    .Where(c => c.Id == cursoId.Value)
                                    .Select(c => (int?)c.UsuarioId)
                                    .FirstOrDefaultAsync();

            if (donoDoCursoId == null || donoDoCursoId.Value.ToString() != idUsuarioLogado)
            {
                _logger.LogWarning($"Falha de autorização: Usuário {idUsuarioLogado} tentou criar aula para o curso {cursoId.Value}.");
                return Forbid();
            }

            var aula = new Aula { CursoId = cursoId.Value };

            return View(aula);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Titulo,Descricao,Duracao,Status,CursoId")] Aula aula,
            IFormFile? arquivo)
        {
            
            var idUsuarioLogado = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var cursoIdParaAdicionar = aula.CursoId;
            var donoDoCursoId = await _context.Cursos
                                    .AsNoTracking()
                                    .Where(c => c.Id == cursoIdParaAdicionar)
                                    .Select(c => (int?)c.UsuarioId)
                                    .FirstOrDefaultAsync();

            if (donoDoCursoId == null)
            {
                ModelState.AddModelError("CursoId", "O curso selecionado não foi encontrado.");
            }
            else if (donoDoCursoId.Value.ToString() != idUsuarioLogado)
            {
                _logger.LogWarning($"Falha de autorização: Usuário {idUsuarioLogado} tentou criar aula no curso {cursoIdParaAdicionar} (do usuário {donoDoCursoId.Value}).");
                ModelState.AddModelError(string.Empty, "Você não tem permissão para criar uma aula neste curso.");
            }
            
            if (ModelState.IsValid)
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    string pastaUploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/aulas");
                    
                    if (!Directory.Exists(pastaUploads))
                    {
                        Directory.CreateDirectory(pastaUploads);
                    }

                    string nomeArquivoUnico = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                    string caminhoCompleto = Path.Combine(pastaUploads, nomeArquivoUnico);

                    using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                    }

                    aula.NomeArquivo = arquivo.FileName;
                    aula.TipoArquivo = arquivo.ContentType;
                    aula.TamanhoArquivo = arquivo.Length;
                    aula.CaminhoArquivo = "/uploads/aulas/" + nomeArquivoUnico; 
                }

                aula.Status = Status.Ativo;
                _context.Add(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { cursoId = aula.CursoId });

            }
            
            return View(aula);

        }

        [Authorize(Policy = "DonoDoCurso")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null) return NotFound();

            return View(aula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "DonoDoCurso")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Duracao,Status,NomeArquivo,CaminhoArquivo,TipoArquivo,TamanhoArquivo,CursoId")] Aula aula,
            IFormFile? arquivo)
        {
            if (id != aula.Id) return NotFound();

            var idUsuarioLogado = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cursoIdDaAula = aula.CursoId; 
            var donoDoCursoId = await _context.Cursos
                                    .AsNoTracking()
                                    .Where(c => c.Id == cursoIdDaAula)
                                    .Select(c => (int?)c.UsuarioId)
                                    .FirstOrDefaultAsync();

            if (donoDoCursoId == null)
            {
                ModelState.AddModelError("CursoId", "O curso associado não foi encontrado.");
            }
            else if (donoDoCursoId.Value.ToString() != idUsuarioLogado)
            {
                _logger.LogWarning($"Falha de autorização: Usuário {idUsuarioLogado} tentou editar aula {id} do curso {cursoIdDaAula}.");
                ModelState.AddModelError(string.Empty, "Você não tem permissão para editar esta aula.");
            }

            var aulaAAtualizar = await _context.Aulas.FindAsync(id);
            if (aulaAAtualizar == null) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (arquivo != null && arquivo.Length > 0)
                    {
                        
                        string pastaUploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/aulas");
                        if (!Directory.Exists(pastaUploads)) Directory.CreateDirectory(pastaUploads);

                        if (!string.IsNullOrEmpty(aulaAAtualizar.CaminhoArquivo))
                        {
                            string caminhoAntigoCompleto = Path.Combine(_webHostEnvironment.WebRootPath, aulaAAtualizar.CaminhoArquivo.TrimStart('/'));
                            if (System.IO.File.Exists(caminhoAntigoCompleto))
                            {
                                System.IO.File.Delete(caminhoAntigoCompleto);
                            }
                        }

                        string nomeArquivoUnico = Guid.NewGuid().ToString() + "_" + arquivo.FileName;
                        string caminhoCompleto = Path.Combine(pastaUploads, nomeArquivoUnico);
                        using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            await arquivo.CopyToAsync(fileStream);
                        }

                        aulaAAtualizar.NomeArquivo = arquivo.FileName;
                        aulaAAtualizar.TipoArquivo = arquivo.ContentType;
                        aulaAAtualizar.TamanhoArquivo = arquivo.Length;
                        aulaAAtualizar.CaminhoArquivo = "/uploads/aulas/" + nomeArquivoUnico;
                    }

                    aulaAAtualizar.Titulo = aula.Titulo;
                    aulaAAtualizar.Descricao = aula.Descricao;
                    aulaAAtualizar.Duracao = aula.Duracao;
                    aulaAAtualizar.Status = aula.Status;

                    _context.Update(aulaAAtualizar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index), new { cursoId = aulaAAtualizar.CursoId });
            }
            
            return View(aula);

        }
        
        [Authorize(Policy = "DonoDoCurso")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "DonoDoCurso")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);
            
            if (aula == null)
            {
                return RedirectToAction("Index", "Cursos");
            }

            int cursoIdParaRedirecionar = aula.CursoId;

            if (aula != null)
            {

                if (!string.IsNullOrEmpty(aula.CaminhoArquivo))
                {
                    string caminhoCompleto = Path.Combine(_webHostEnvironment.WebRootPath, aula.CaminhoArquivo.TrimStart('/'));
                    if (System.IO.File.Exists(caminhoCompleto))
                    {
                        System.IO.File.Delete(caminhoCompleto);
                    }
                }

                _context.Aulas.Remove(aula);

            }

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index), new { cursoId = cursoIdParaRedirecionar });  

        }

        private bool AulaExists(int id)
        {
            return _context.Aulas.Any(e => e.Id == id);
        }
    }
}
