using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using Restaurant.ViewsModel;

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
            var menuler = await _context.Menuler
                .Include(m => m.Kategori) 
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            var urunler = await _context.Urunler
                .Include(m => m.Kategori) 
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            var personeller = await _context.Personeller
                .Include(x => x.Rol)
                .Where(p => p.Gorunurluk == true).ToListAsync();

            var viewModel = new ListeEklemeViewsModel
            {
                Menuler = menuler,
                Urunler = urunler,
                Personeller = personeller
            };

            return View(viewModel);
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult İletisim()
        {
            return View();
        }

        public IActionResult Begenme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Begenme(int MenuId)
        {
            return View();
        }
    }
}
