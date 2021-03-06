using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Usuarios;
using Unisul.PrestaSys.Web.Models.Login;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult About()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string senha)
        {
            if (!ModelState.IsValid) return View("Index");
            var usuario = _usuarioService.GetUsuarioByEmailAndSenha(email, senha);

            if (usuario != null)
            {
                LogarUsuario(usuario, false);

                return RedirectToAction("Index", "Prestacoes");
            }

            ModelState.AddModelError(string.Empty, "Usuário ou Senha inválidos, por favor tente novamente.");


            return View("Index");
        }

        public IActionResult Logoff()
        {
            var authenticationManager = Request.HttpContext;

            authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View(new LoginViewModel());
        }

        private void LogarUsuario(Usuario loginUsuario, bool isPersistent)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, loginUsuario.Email), new Claim(ClaimTypes.Name, loginUsuario.Nome)
            };

            var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdenties);
            var authenticationManager = Request.HttpContext;

            authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimPrincipal, new AuthenticationProperties {IsPersistent = isPersistent});
        }
    }
}
