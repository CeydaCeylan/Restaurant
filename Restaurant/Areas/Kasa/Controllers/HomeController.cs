using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Kasa.Controllers
{
	[Area("Kasa")]
    [Authorize(Roles = "Kasa")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
