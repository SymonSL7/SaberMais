using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace SaberMais.Controllers
{
    [Authorize]
    public class MatriculasController : Controller
    {
        private readonly AppDbContext _context;

        public MatriculasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inscrever(int cursoId)
        {

            var usuarioIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(usuarioIdString) || !int.TryParse(usuarioIdString, out int usuarioId))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var curso = await _context.Cursos.FindAsync(cursoId);
            if (curso == null)
            {
                TempData["ErrorMessage"] = "Curso não encontrado.";
                return RedirectToAction("Index", "Cursos");
            }


            bool jaInscrito = await _context.Matriculas
                .AnyAsync(m => m.UsuarioId == usuarioId
                            && m.CursoId == cursoId
                            && m.Situacao); 

            if (jaInscrito)
            {
                TempData["ErrorMessage"] = "Você já está inscrito neste curso.";
                return RedirectToAction("Details", "Cursos", new { id = cursoId });
            }


            var matricula = new Matricula
            {
                UsuarioId = usuarioId,
                CursoId = cursoId,
                DataMatricula = DateTime.Now,
                Situacao = true,
                Concluido = false
            };

            _context.Matriculas.Add(matricula);


            curso.QtdInscritos++;
            _context.Cursos.Update(curso);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Inscrição realizada com sucesso!";
            return RedirectToAction("Details", "Cursos", new { id = cursoId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarInscricao(int cursoId)
        {
            var usuarioIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (usuarioIdString == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            int usuarioId = int.Parse(usuarioIdString);

            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.UsuarioId == usuarioId
                                       && m.CursoId == cursoId);

            if (matricula == null)
            {
                TempData["ErrorMessage"] = "Inscrição não encontrada.";
                return RedirectToAction("Details", "Cursos", new { id = cursoId });
            }

            //matricula.Situacao = false;
            _context.Matriculas.Remove(matricula);

            var curso = await _context.Cursos.FindAsync(cursoId);
            if (curso != null && curso.QtdInscritos > 0)
            {
                curso.QtdInscritos--;
                _context.Cursos.Update(curso);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Inscrição cancelada com sucesso!";
            return RedirectToAction("Details", "Cursos", new { id = cursoId });
        }
    }
}
