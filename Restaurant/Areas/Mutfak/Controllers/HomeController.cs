using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Mutfak.Controllers
{
    [Area("Mutfak")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
