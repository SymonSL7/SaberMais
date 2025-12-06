using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaberMais.Models;

namespace SaberMais.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class AulasConcluidasController : Controller
    {
        private readonly ILogger<AulasConcluidasController> _logger;
        private readonly AppDbContext _context;

        public AulasConcluidasController(AppDbContext context, ILogger<AulasConcluidasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarComoConcluida(int aulaId)
        {
            
            var usuarioIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (usuarioIdString == null) return Challenge();

            int usuarioId = int.Parse(usuarioIdString);

            var aula = await _context.Aulas
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == aulaId);

            if(aula == null) return NotFound("Aula não encontrada");

            var cursoId = aula.CursoId;

            var matricula = await _context.Matriculas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CursoId == cursoId && m.UsuarioId == usuarioId);

            if(matricula == null) return Unauthorized("Usuario não está matricuLado neste cursos");
          
            var matriculaId = matricula.Id;

            bool jaConcluida = await _context.AulaConcluidas
                .AnyAsync(ac => ac.AulaId == aulaId && ac.MatriculaId == matriculaId);

            if(jaConcluida)
            {
                TempData["MensagemAviso"] =  "Você já concluiu esta aula!";
                return RedirectToAction("Details", "Aulas", new { id = aulaId});
            }

            var novaConclusao = new AulaConcluida
            {
                Id = Guid.NewGuid().ToString(),
                MatriculaId = matriculaId,
                AulaId = aulaId,
                Concluida = true,
                DataConclusao = DateTime.Now
            };

            _context.AulaConcluidas.Add(novaConclusao);
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] =  "Aula concluída com sucesso!";
            return RedirectToAction("Details", "Aulas", new { id = aulaId } );

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}