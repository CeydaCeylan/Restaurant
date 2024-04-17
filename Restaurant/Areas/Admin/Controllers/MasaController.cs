using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MasaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MasaEkle()
        {
            return View();
        }

        public IActionResult MasaListele()
        {
            return View();
        }
    }
}
