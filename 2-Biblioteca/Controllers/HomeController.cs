using _2_Biblioteca.Models;
using _2_Biblioteca.Services.IServices;
using _2_Biblioteca.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2_Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IRolServices _rolServices;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUsuarioServices usuarioServices, IRolServices rolServices)
        {
            _logger = logger;
            _usuarioServices = usuarioServices;
            _rolServices = rolServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalUsuarios = await _usuarioServices.GetTotalUsuarios();
            ViewBag.TotalRoles = await _rolServices.GetTotalRoles();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
