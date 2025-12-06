using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;

namespace SaberMais.Authorization
{
public class ManipuladorAutorizacaoDonoDoCurso : AuthorizationHandler<RequisitoDonoDoCurso>
    {
        
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ManipuladorAutorizacaoDonoDoCurso> _logger;

        public ManipuladorAutorizacaoDonoDoCurso(
            AppDbContext dbContext,
            ILogger<ManipuladorAutorizacaoDonoDoCurso> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext contexto, RequisitoDonoDoCurso requisito)
        {
            
            var idUsuarioLogado = contexto.User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            if (contexto.Resource is not HttpContext contextoHttp)
            {
                _logger.LogWarning("O recurso (Resource) não é um HttpContext.");
                contexto.Fail();
                return;
            }

            var idAulaDaRota = contextoHttp.Request.RouteValues["id"]?.ToString();

            if (string.IsNullOrEmpty(idUsuarioLogado) || string.IsNullOrEmpty(idAulaDaRota))
            {
                _logger.LogWarning("Não foi possível encontrar idUsuarioLogado ou idAulaDaRota.");
                contexto.Fail();
                return;
            }

            try
            {
                
                if (!int.TryParse(idAulaDaRota, out int aulaIdNumerico))
                {
                    _logger.LogWarning($"ID da aula na rota ({idAulaDaRota}) não é um inteiro válido.");
                    contexto.Fail();
                    return;
                }

                var donoDoCursoId = await _dbContext.Aulas
                                    .AsNoTracking() 
                                    .Where(a => a.Id == aulaIdNumerico)  
                                    .Select(a => (int?)a.Curso.UsuarioId)  
                                    .FirstOrDefaultAsync();

                if (donoDoCursoId == null)
                {
                    _logger.LogWarning($"Aula (ID: {aulaIdNumerico}) ou Curso associado não encontrado.");
                    contexto.Fail(); 
                    return;
                }

                if (donoDoCursoId.Value.ToString().Equals(idUsuarioLogado))
                {
                    contexto.Succeed(requisito);
                }
                else
                {
                    _logger.LogWarning($"Falha na autorização: Usuário {idUsuarioLogado} não é dono (Dono do Curso: {donoDoCursoId}) da aula {aulaIdNumerico}.");
                    contexto.Fail();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar autorização da aula via curso.");
                contexto.Fail();
            }
        }
    }
}