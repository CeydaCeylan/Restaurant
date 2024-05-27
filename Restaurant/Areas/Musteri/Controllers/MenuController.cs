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
        private const int PageSize = 4;
        private readonly List<string> SampleData = Enumerable.Range(1, 300).Select(i => $"Item {i}").ToList();      

        public async Task<IActionResult> Index(string arama, int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }

            var menusQuery = _context.Menuler
                                .Include(m => m.Kategori)
                                .Where(m => m.Gorunurluk == true);

            if (!string.IsNullOrEmpty(arama))
            {
                menusQuery = menusQuery.Where(m => m.Ad.Contains(arama));
            }
            var menus = await menusQuery.ToListAsync();

            if (menus.Count == 0)
            {
                TempData["ErrorMessage"] = "EŞLEŞEN BİR SONUÇ BULUNAMADI!";
                return RedirectToAction("Index");
            }
                 
            var totalItems = await menusQuery.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            var startIndex = (page - 1) * PageSize;
            var endIndex = Math.Min(startIndex + PageSize - 1, totalItems - 1);

            var pageData = await menusQuery.Skip(startIndex).Take(PageSize).ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            ViewBag.SearchTerm = arama;

            return View(pageData);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var menus = await _context.Menuler
               .Include(m => m.Kategori) 
               .Where(m => m.Gorunurluk == true && m.Id == id)
               .ToListAsync();

            return View(menus);
        }
    }
}
