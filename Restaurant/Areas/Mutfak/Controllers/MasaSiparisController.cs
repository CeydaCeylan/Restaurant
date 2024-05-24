using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Mutfak.Controllers
{

    [Area("Mutfak")]
    public class MasaSiparisController : Controller
    {
        private readonly IdentityDataContext _context;

        public MasaSiparisController(IdentityDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Onayla()
        {
            var durum2Siparisler = await _context.MasaSiparisler
               .Include(m => m.Masa)
                                   .Include(s => s.Siparis)
                                   .ThenInclude(a => a.SiparisMenuler)
                                   .ThenInclude(sm => sm.Menu)
                                   .Include(s => s.Siparis)
                                   .ThenInclude(z => z.SiparisUrunler)
                                   .ThenInclude(sm => sm.Urun)
               .Include(ms => ms.Siparis)
                   .ThenInclude(s => s.Durumlars)
               .Where(ms => ms.Siparis.Durumlars.Any(d => d.Ad == 2))
               .ToListAsync();

            return View(durum2Siparisler);
        }

       
    }
}
