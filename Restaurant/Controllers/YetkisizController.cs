using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class YetkisizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
