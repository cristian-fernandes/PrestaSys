using System;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Privacy()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Login(string email, string senha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioService.GetUsuarioByEmailAndSenha(email, senha);

                    if (usuario != null)
                    {
                         LogarUsuario(usuario, false);

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

        public IActionResult Logoff()
        {
            try
            {
                var authenticationManager = Request.HttpContext;

                 authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index");
        }

        private void LogarUsuario(Usuario loginUsuario, bool isPersistent)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Email, loginUsuario.Email));
                claims.Add(new Claim(ClaimTypes.Name, loginUsuario.Nome));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                 authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimPrincipal, new AuthenticationProperties {IsPersistent = isPersistent});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
