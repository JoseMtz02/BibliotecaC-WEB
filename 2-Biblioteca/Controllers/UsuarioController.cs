using _2_Biblioteca.Services.IServices;
using _2_Biblioteca.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace _2_Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioService)
        {
            _usuarioServices = usuarioService;
        }
        public IActionResult Index()
        {
            var result = _usuarioServices.GetUsuarios();
            return View(result);
        }
    }
}
