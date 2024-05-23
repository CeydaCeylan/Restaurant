using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Kasa.Controllers
{
	[Area("Kasa")]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
