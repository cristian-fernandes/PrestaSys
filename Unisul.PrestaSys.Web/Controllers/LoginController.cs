using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Repositorio;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IPrestaSysDbContext _dbContext;
        private readonly IUsuarioService _usuarioService;

        public LoginController(IPrestaSysDbContext dbContext, IUsuarioService usuarioService) : base(usuarioService)
        {
            _dbContext = dbContext;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var listaUsuarios = _dbContext.Usuario.Where(u => u.Email == email && u.Senha == senha).ToList();

                    if (listaUsuarios.Count > 0)
                    {
                        var usuario = listaUsuarios.First();

                        await LogarUsuario(usuario, false);

                        return RedirectToAction("Index", "Prestacoes");
                    }

                    ModelState.AddModelError("IncorrectUser", "Usuário ou Senha inválidos.");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return View("Index");
        }

        public async Task<IActionResult> Logoff()
        {
            try
            {
                var authenticationManager = Request.HttpContext;

                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index");
        }

        private async Task LogarUsuario(Usuario loginUsuario, bool isPersistent)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Email, loginUsuario.Email));
                claims.Add(new Claim(ClaimTypes.Name, loginUsuario.Nome));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimPrincipal, new AuthenticationProperties {IsPersistent = isPersistent});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
