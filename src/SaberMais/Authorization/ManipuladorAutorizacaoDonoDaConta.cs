using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SaberMais.Authorization;


namespace SaberMais.Autorizacao
{
    public class ManipuladorAutorizacaoDonoDaConta : AuthorizationHandler<RequisitoDeveSerDonoDaConta>
    {
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext contexto, RequisitoDeveSerDonoDaConta requisito)
        {

            if (contexto.Resource is not HttpContext contextoHttp)
            {
                contexto.Fail(); 
                return Task.CompletedTask;
            }
        
            var idUsuarioLogado = contexto.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var idUsuarioDaRota = contextoHttp.Request.RouteValues["id"]?.ToString();

            if (string.IsNullOrEmpty(idUsuarioLogado) || string.IsNullOrEmpty(idUsuarioDaRota))
            {
                contexto.Fail();
                return Task.CompletedTask;
            }

            if (idUsuarioLogado.Equals(idUsuarioDaRota))
            {
                
                contexto.Succeed(requisito);
            }
            else
            {
                
                contexto.Fail();
            }

            return Task.CompletedTask;
        }
    }
}