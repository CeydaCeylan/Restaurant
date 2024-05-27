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

        public async Task<IActionResult> Index(string arama, string category, int page = 1, int pageSize = 4)
        {
            // Ürünlerin temel sorgusu
            var uruns = from m in _context.Urunler.Include(m => m.Kategori)
                        select m;

            // Arama ifadesine göre filtreleme
            if (!string.IsNullOrEmpty(arama))
            {
                uruns = uruns.Where(s => s.Ad.Contains(arama));
            }

            // Kategoriye göre filtreleme
            if (!string.IsNullOrEmpty(category))
            {
                uruns = uruns.Where(x => x.Kategori.Ad == category);
            }

            // Sayfalama işlemi için toplam veri sayısını alın
            var totalItems = await uruns.CountAsync();

            // Toplam sayfa sayısını hesaplayın
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Geçerli sayfa numarasını sınırlandırın
            page = Math.Max(1, Math.Min(page, totalPages));

            // Verileri sayfalara göre alın
            var pagedUruns = await uruns
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Sayfalama verilerini view'e iletmek için ViewBag kullanabilirsiniz
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedUruns);
        }
    

    public async Task<IActionResult> Detay(int id)
        {
            var uruns = await _context.Urunler
               .Include(m => m.Kategori) 
               .Where(m => m.Gorunurluk == true && m.Id == id)
               .ToListAsync();

            return View(uruns);
        }
    }
}
