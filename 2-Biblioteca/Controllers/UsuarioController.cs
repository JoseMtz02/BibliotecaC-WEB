using _2_Biblioteca.Models.Domain;
using _2_Biblioteca.Services.IServices;
using _2_Biblioteca.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _2_Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IRolServices _rolServices;

        public UsuarioController(IUsuarioServices usuarioService, IRolServices rolServices)
        {
            _usuarioServices = usuarioService;
            _rolServices = rolServices;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _usuarioServices.GetUsuarios();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            List<Rol> result = await _rolServices.GetAll();
            ViewBag.Roles = result.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            List<Rol> rol = await _rolServices.GetAll();
            ViewBag.Roles = rol.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });

            var result = await _usuarioServices.GetbyId(id);
            return View(result);
        }



        [HttpPost]
       public  IActionResult Crear(Usuario request)
        {
            var result = _usuarioServices.AddUser(request);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _usuarioServices.DeleteUser(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
