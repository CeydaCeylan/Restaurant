using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Garson.Controllers
{
    [Area("Garson")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
