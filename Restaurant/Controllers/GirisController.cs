using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{

    public class GirisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SifremiUnuttum()
        {
            return View();
        }
    }
}
