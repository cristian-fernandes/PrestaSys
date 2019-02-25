using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prestacao.Models;
using Repositorio;

namespace Prestacao.Controllers
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
