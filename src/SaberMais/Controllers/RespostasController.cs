using Microsoft.AspNetCore.Mvc;
using SaberMais.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SaberMais.Controllers
{
    [Authorize]
    public class RespostasController : Controller
    {
        private readonly AppDbContext _context;

        public RespostasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int perguntaId, string conteudo, int aulaId)
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
                TempData["ErrorMessage"] = "O conteúdo da resposta não pode estar vazio.";
                return RedirectToAction("Details", "Aulas", new { id = aulaId });
            }

            var pergunta = await _context.Perguntas.FindAsync(perguntaId);
            if (pergunta == null)
            {
                return NotFound();
            }

            var resposta = new Resposta
            {
                PerguntaId = perguntaId,
                UsuarioId = usuarioIdFormatado,
                Conteudo = conteudo,
                Data = System.DateTime.Now
            };

            _context.Respostas.Add(resposta);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Sua resposta foi enviada.";
            return RedirectToAction("Details", "Aulas", new { id = aulaId });
        }
    }
}