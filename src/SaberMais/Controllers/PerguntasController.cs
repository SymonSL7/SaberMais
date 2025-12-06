using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;
using System;
using System.Linq;
using System.Security.Claims;


namespace SaberMais.Controllers
{
    [Authorize]
    public class PerguntasController : Controller
    {
        private readonly AppDbContext _context;

        public PerguntasController(AppDbContext context)
        {
            _context = context;
        }

        // Lista todas as perguntas
        public IActionResult Index(int? aulaId)
        {
            var perguntas = _context.Perguntas
                .Include(p => p.Usuario)
                .Include(p => p.Respostas)
                .ThenInclude(r => r.Usuario)
                .AsQueryable();

            if (aulaId != null)
                perguntas = perguntas.Where(p => p.AulaId == aulaId);

            ViewBag.AulaId = aulaId;

            return View(perguntas.ToList());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int aulaId, string conteudo)
        {

            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (usuarioId == null)
            {
                return Unauthorized();
            }

            if (!int.TryParse(usuarioId, out int usuarioIdFormatado))
            {
                return BadRequest("Formato de ID de usuário inválido.");
            }

            if (string.IsNullOrWhiteSpace(conteudo))
            {
                TempData["ErrorMessage"] = "O conteúdo da pergunta não pode estar vazio.";
                return RedirectToAction("Details", "Aulas", new { id = aulaId });
            }

            var aula = await _context.Aulas.FindAsync(aulaId);
            if (aula == null)
            {
                return NotFound();
            }

            var pergunta = new Pergunta
            {
                AulaId = aulaId,
                UsuarioId = usuarioIdFormatado,
                Conteudo = conteudo,
                Data = System.DateTime.Now
            };

            _context.Perguntas.Add(pergunta);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Sua pergunta foi enviada.";
            return RedirectToAction("Details", "Aulas", new { id = aulaId });
        }
    }
}