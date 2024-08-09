using Microsoft.AspNetCore.Mvc;

namespace MiProyectoWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
