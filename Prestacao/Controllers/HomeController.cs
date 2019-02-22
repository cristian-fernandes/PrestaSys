using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prestacao.Models;

namespace Prestacao.Controllers
{
    public class HomeController : BaseController
    {
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
