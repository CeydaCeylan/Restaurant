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
            // Menülerin listesi
            var menuler = await _context.Menuler
                .Include(m => m.Kategori) // Menü kategorilerini dahil et
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            // Ürünlerin listesi
            var urunler = await _context.Urunler
                .Include(m => m.Kategori) // Menü kategorilerini dahil et
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            // Personellerin listesi
            var personeller = await _context.Personeller
                .Include(x => x.Rol)
                .Where(p => p.Gorunurluk == true).ToListAsync();

            // View model oluşturma
            var viewModel = new ListeEklemeViewsModel
            {
                Menuler = menuler,
                Urunler = urunler,
                Personeller = personeller
            };

            // View modeli view'a gönderme
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
