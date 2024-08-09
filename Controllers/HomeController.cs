using Microsoft.AspNetCore.Mvc;
using MiProyectoWeb.Models;

namespace MiProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Crear una instancia del modelo y asignar un valor a la propiedad Propiedad
            var model = new IndexModel
            {
                Propiedad = "Valor de ejemplo" // O el valor que desees pasar a la vista
            };

            // Pasar el modelo a la vista
            return View(model);
        }
    }
}
