using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Unisul.PrestaSys.Dominio.Servicos.Usuarios;
using Unisul.PrestaSys.Web.Models;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
