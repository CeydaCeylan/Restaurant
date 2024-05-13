using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class UrunController : Controller
    {
        private readonly IdentityDataContext _context;

        public UrunController(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Tüm görünür menüleri al
            var uruns = await _context.Urunler
                .Include(m => m.Kategori) // Menü kategorilerini dahil et
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            return View(uruns);
        }
    }
}
