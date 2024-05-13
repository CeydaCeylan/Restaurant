using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class SepetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int MenuId)
        {
            return View();
        }
    }
}
