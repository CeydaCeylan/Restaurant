using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Garson.Controllers
{
    [Area("Garson")]

    public class MasaController : Controller
    {
        private readonly IdentityDataContext _context;

        public MasaController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Ozellikler = await _context.Ozellikler.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Ad
            }).ToListAsync();
            var masa = await _context.Masalar
                               .Include(m => m.MasaOzellikler)
                               .ThenInclude(muhammed => muhammed.Ozellik)
                               .Where(p => p.Gorunurluk == true)
                               .ToListAsync();
            ViewBag.Kategoriler = new SelectList(await _context.Kategoriler.ToListAsync(), "Id", "KategoriAd");

            return View(masa);
        }
    }
}
