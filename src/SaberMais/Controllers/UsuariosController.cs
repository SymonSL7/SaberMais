using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaberMais.Models;

namespace SaberMais.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Usuarios
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Cursos");
        }

        [Authorize]
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Cursos");
            }
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Nome,Senha,ConfirmarSenha,Descricao,Tipo")] Usuario usuario)
        {

            var emailNormalizado = usuario.Email?.Trim().ToLowerInvariant();

            var emailExistente = await _context.Usuarios
                .AnyAsync(u => u.Email == emailNormalizado);

            if (emailExistente)
            {
                ModelState.AddModelError("Email", "Este e-mail já está em uso. Por favor, escolha outro.");
            }

            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                usuario.Email = emailNormalizado;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }

        [Authorize(Policy = "EhDonoDaConta")]
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Policy = "EhDonoDaConta")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuarioFormData)
        {
            if (id != usuarioFormData.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Id");
            ModelState.Remove("Email");
            ModelState.Remove("Tipo");
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmarSenha");

            if (ModelState.IsValid)
            {
                var usuarioDoBanco = await _context.Usuarios.FindAsync(id);

                if (usuarioDoBanco == null)
                {
                    return NotFound();
                }

                try
                {
                    usuarioDoBanco.Nome = usuarioFormData.Nome;
                    usuarioDoBanco.Descricao = usuarioFormData.Descricao;

                    if (!string.IsNullOrEmpty(usuarioFormData.Senha))
                    {
                        usuarioDoBanco.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioFormData.Senha);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new {id = id});
            }

            var usuarioParaRetornar = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            usuarioParaRetornar.Nome = usuarioFormData.Nome;
            usuarioParaRetornar.Descricao = usuarioFormData.Descricao;
            return View(usuarioParaRetornar);
        }

        [Authorize(Policy = "EhDonoDaConta")]
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [Authorize(Policy = "EhDonoDaConta")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Matriculas)
                    .ThenInclude(m => m.AulasConcluidas)
                .Include(u => u.Matriculas)
                    .ThenInclude(m => m.Curso)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null) return NotFound();

            foreach (var matricula in usuario.Matriculas)
            {
                if (matricula.Curso != null && matricula.Curso.QtdInscritos > 0)
                {
                    matricula.Curso.QtdInscritos--;
                    _context.Cursos.Update(matricula.Curso);
                }

                _context.AulaConcluidas.RemoveRange(matricula.AulasConcluidas);
            }

            _context.Matriculas.RemoveRange(usuario.Matriculas);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Logout));
        }

        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Cursos");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {

            var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == usuario.Email);

            if (dados == null || !BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha))
            {

                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();

            }

            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                new Claim(ClaimTypes.Name, dados.Nome),
                new Claim(ClaimTypes.Email, dados.Email.ToLower()),
                new Claim("Descricao", dados.Descricao ?? ""),
                new Claim(ClaimTypes.Role, dados.Tipo.ToString())

            };

            var usuarioIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(usuarioIdentity);

            var props = new AuthenticationProperties
            {

                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(12),
                IsPersistent = true

            };

            await HttpContext.SignInAsync(principal, props);

            return RedirectToAction("Index", "Cursos");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = "EhDonoDaConta")]
        public async Task<IActionResult> AlterarSenha(int? id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var model = new AlterarSenhaViewModel { Id = usuario.Id };
            return View(model);
        }

        [Authorize(Policy = "EhDonoDaConta")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuarioDoBanco = await _context.Usuarios.FindAsync(model.Id);
            if (usuarioDoBanco == null)
            {
                return NotFound();
            }

            if (!BCrypt.Net.BCrypt.Verify(model.SenhaAtual, usuarioDoBanco.Senha))
            {

                ModelState.AddModelError("SenhaAtual", "A senha atual está incorreta.");
                return View(model);

            }

            if (BCrypt.Net.BCrypt.Verify(model.NovaSenha, usuarioDoBanco.Senha))
            {   

                ModelState.AddModelError("NovaSenha", "A nova senha é igual a senha atual");
                return View(model);
                
            }

            var novaSenhaHash = BCrypt.Net.BCrypt.HashPassword(model.NovaSenha);

            usuarioDoBanco.Senha = novaSenhaHash;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Senha alterada com sucesso!";
            return RedirectToAction(nameof(Logout));

        }

        [AllowAnonymous]
        public IActionResult SolicitarRedefinicaoSenha()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Cursos");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SolicitarRedefinicaoSenha(SolicitarRedefinicaoSenhaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            string mensagemUsuario = null;

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == modelo.Email);

            if (usuario != null)
            {

                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));


                usuario.TokenRedefinicaoSenha = token;
                usuario.DataExpiracaoToken = DateTime.UtcNow.AddHours(1);
                await _context.SaveChangesAsync();


                var tokenCodificadoParaUrl = WebUtility.UrlEncode(token);


                var linkRedefinicao = Url.Action(
                    "RedefinirSenha",
                    "Usuarios",
                    new { email = usuario.Email, token = tokenCodificadoParaUrl },
                    protocol: Request.Scheme
                );


                mensagemUsuario = $"<b>LINK DE SIMULAÇÃO (Copie e cole no navegador):</b><br>{linkRedefinicao}";
            }


            TempData["SuccessMessage"] = mensagemUsuario;
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RedefinirSenha(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                TempData["ErrorMessage"] = "Link de redefinição inválido.";
                return RedirectToAction("Login");
            }

            var modelo = new RedefinirSenhaViewModel
            {
                Email = email,
                Token = token
            };

            return View(modelo);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RedefinirSenha(RedefinirSenhaViewModel modelo)
        {
            
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            
            var tokenDecodificado = WebUtility.UrlDecode(modelo.Token);

            
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Email == modelo.Email &&
                u.TokenRedefinicaoSenha == tokenDecodificado
            );

            
            if (usuario == null || usuario.DataExpiracaoToken <= DateTime.UtcNow)
            {
                
                ModelState.AddModelError(string.Empty, "Link de redefinição inválido ou expirado. Por favor, solicite um novo.");
                return View(modelo);
            }

            
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(modelo.NovaSenha);

            
            usuario.TokenRedefinicaoSenha = null;
            usuario.DataExpiracaoToken = null;

            
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            
            TempData["SuccessMessage"] = "Sua senha foi redefinida com sucesso! Você já pode fazer o login.";
            return RedirectToAction("Login");
            
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
