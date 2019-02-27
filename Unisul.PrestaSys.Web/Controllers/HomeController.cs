using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Unisul.PrestaSys.Web.Models;
using Unisul.PrestaSys.Repositorio;

namespace Unisul.PrestaSys.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly PrestacaoDbContext _context;

        public HomeController(PrestacaoDbContext context) : base(context)
        {
            _context = context;
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
