using Gestor_Proyectos_ddh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gestor_Proyectos_ddh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Gestionar()
        {
            return View(sql_proyectos.sel(1));
        }

        Servicios.S_proyectos sql_proyectos = new Servicios.S_proyectos();
        [HttpPost]
        public IActionResult recibir(Proyectos p)
        {
            if(!ModelState.IsValid)
            {
                return View("Crear", p);
            }
            sql_proyectos.crear_proyecto(p);
            TempData["mensaje"] = "Proyecto creado con exito";
            return RedirectToAction("Crear");
        }

        public IActionResult Actualizar(int id)
        {
            var proyecto = sql_proyectos.sel(0).FirstOrDefault(p => p.ID_PROYECTO == id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return View(proyecto);
        }

        [HttpPost]
        public IActionResult Actualizar(Proyectos proyecto)
        {
            if (ModelState.IsValid)
            {
                sql_proyectos.ActualizarProyecto(proyecto);
                return RedirectToAction("Gestionar");
            }
            return View(proyecto);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            sql_proyectos.EliminarProyecto(id);
            return RedirectToAction("Gestionar");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
