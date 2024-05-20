using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class SepetController : Controller
    {
        private readonly IdentityDataContext _context;

        public SepetController(IdentityDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menuler
                .Include(m => m.Kategori) 
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();


            var uruns = await _context.Urunler
                .Include(m => m.Kategori)
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            return View(menus);
        }

        public async Task<IActionResult> MenuSepet(int id)
        {
            var menu = await _context.Menuler
                .FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            return Json(menu);
        }

        public async Task<IActionResult> UrunSepet(int id)
        {
            var urun = await _context.Urunler
                .FirstOrDefaultAsync(x => x.Id == id);
            if (urun == null)
            {
                return NotFound();
            }
            return Json(urun);
        }
    }
}
