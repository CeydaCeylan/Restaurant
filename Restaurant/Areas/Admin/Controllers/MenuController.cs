using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
