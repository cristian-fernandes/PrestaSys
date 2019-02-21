using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Prestacao.Models.Database;


namespace Prestacao.Controllers
{
    public class LoginController : Controller
    {
        private readonly PrestacaoDbContext databaseManager;

        public LoginController(PrestacaoDbContext databaseManagerContext)
        {
            try
            {
                // Settings.  
                this.databaseManager = databaseManagerContext;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Initialization.  
                    var loginInfo = await this.databaseManager.LoginByEmailSenhaMethodAsync(email, senha);

                    // Verification.  
                    if (loginInfo != null && loginInfo.Count > 0)
                    {
                        // Initialization.  
                        var logindetails = loginInfo.First();

                        // Login In.  
                        await this.LogarUsuario(logindetails, false);

                        // Info.  
                        return this.RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Setting.  
                        ModelState.AddModelError("IncorrectUser", "Usuário ou Senha inválidos.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info  
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

        private async Task LogarUsuario(LoginUsuario loginUsuario, bool isPersistent)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Email, loginUsuario.Email));
                claims.Add(new Claim(ClaimTypes.Name, loginUsuario.Nome));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Log In
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }
    }
}
