using _2_Biblioteca.Models.Domain;
using _2_Biblioteca.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace _2_Biblioteca.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolServices _rolServices;

        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _rolServices.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Rol request)
        {
            if (ModelState.IsValid)
            {
                var result = await _rolServices.AddRol(request);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "No se pudo agregar el rol.");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var result = await _rolServices.GetbyId(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Rol request)
        {
            if (ModelState.IsValid)
            {
                var result = await _rolServices.UpdateRol(request);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "No se pudo actualizar el rol.");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _rolServices.DeleteRol(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}