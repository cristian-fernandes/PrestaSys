using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Prestacao.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                    filterContext.Result = new RedirectResult(Url.Action("Index", "Login"));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
