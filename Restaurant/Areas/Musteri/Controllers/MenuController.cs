using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class MenuController : Controller
    {
        private readonly IdentityDataContext _context;

        public MenuController(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Tüm görünür menüleri al
            var menus = await _context.Menuler
                .Include(m => m.Kategori) // Menü kategorilerini dahil et
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            return View(menus);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var menus = await _context.Menuler
               .Include(m => m.Kategori) // Menü kategorilerini dahil et
               .Where(m => m.Gorunurluk == true && m.Id == id )
               .ToListAsync();

            return View(menus);
        }
    }
}
