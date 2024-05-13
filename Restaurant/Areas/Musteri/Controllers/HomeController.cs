using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class HomeController : Controller
    {
        private readonly IdentityDataContext _context;

        public HomeController(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var personel = await _context.Personeller.Include(x => x.Rol).Where(p => p.Gorunurluk == true).ToListAsync();
            return View(personel);
        }
        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult İletisim()
        {
            return View();
        }
    }
}
