using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Entidades.Usuarios;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUsuarioService _service;

        public BaseController(IUsuarioService service)
        {
            _service = service;
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

        protected Usuario GetLoggedUser()
        {
            var usuarioLogado = _service.GetUsuarioByEmail(GetClaimValueByType(ClaimTypes.Email));

            if (usuarioLogado != null)
                return usuarioLogado;

            RedirectToAction("Index", "Home");
            return null;
        }

        private string GetClaimValueByType(string type)
        {
            return Request.HttpContext.User.Claims.First(t => t.Type == type).Value;
        }
    }
}
