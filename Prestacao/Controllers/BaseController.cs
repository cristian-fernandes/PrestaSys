using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Repositorio;
using Repositorio.Models.Database;

namespace Prestacao.Controllers
{
    public class BaseController : Controller
    {
        private readonly PrestacaoDbContext _context;


        public BaseController(PrestacaoDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var usuario = GetLoggedUser();

                    ViewBag.Nome = usuario.Nome;
                    ViewBag.Sobrenome = usuario.Sobrenome;
                    ViewBag.Email = usuario.Email;
                    ViewBag.FlagGerenteMenu = usuario.FlagGerente;
                    ViewBag.FlagGerenteFinanceiroMenu = usuario.FlagGerenteFinanceiro;

                }
                else
                {
                    if (filterContext.RouteData.Values["Controller"].ToString() == "Login")
                        return;

                    filterContext.Result = new RedirectResult(Url.Action("Index", "Login"));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public Usuario GetLoggedUser()
        {
            var listaUsuarios = _context.Usuario.Where(u => u.Email == GetClaimValueByType(ClaimTypes.Email)).ToList();

            if (listaUsuarios.Count > 0)
            {
                var usuarioLogado = listaUsuarios.First();

                return usuarioLogado;
            }

            RedirectToAction("Index", "Home");
            return null;
        }

        private string GetClaimValueByType(string type)
        {
            return Request.HttpContext.User.Claims.First(t => t.Type == type).Value;
        }
    }
}
