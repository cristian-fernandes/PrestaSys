using System;
using Microsoft.AspNetCore.Mvc;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Web.Models.Home;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IUsuarioService usuarioService) : base(usuarioService)
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Guid.NewGuid().ToString()
            });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
