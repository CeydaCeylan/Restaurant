using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
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
            var durum = await _context.MasaSiparisler
               .Include(m => m.Masa)
                                   .Include(s => s.Siparis)
                                   .ThenInclude(a => a.SiparisMenuler)
                                   .ThenInclude(sm => sm.Menu)
                                   .Include(s => s.Siparis)
                                   .ThenInclude(z => z.SiparisUrunler)
                                   .ThenInclude(sm => sm.Urun)
               .Include(ms => ms.Siparis)
                   .ThenInclude(s => s.Durumlars)
                   //Zamanın tersine göre sırala ve ilk adı 2 olanı getir.
               .Where(ms => ms.Siparis.Durumlars.OrderByDescending(x=>x.Zaman).FirstOrDefault().Ad == 2)
               .ToListAsync();

            return View(durum);
        }

        public IActionResult MutfakHazırlanacakOnayla()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MutfakHazırlanacakOnayla(int id)
        {
            var siparis = _context.Siparisler
                .Include(a => a.Durumlars)
                .FirstOrDefault(m => m.Id == id);
            if (siparis == null)
            {
                return NotFound();
            }
            var durum = new Durum
            {
                Siparis = siparis,
                Ad = 3,
                Zaman = DateTime.Now,
                Yer = 2,
            };

            _context.Durumlar.Add(durum);
            _context.SaveChanges();

            return RedirectToAction("Onayla");
        }

        public async Task<IActionResult> Hazırlanacak()
        {
            var durum = await _context.MasaSiparisler
                .Include(m => m.Masa)
                                    .Include(s => s.Siparis)
                                    .ThenInclude(a => a.SiparisMenuler)
                                    .ThenInclude(sm => sm.Menu)
                                    .Include(s => s.Siparis)
                                    .ThenInclude(z => z.SiparisUrunler)
                                    .ThenInclude(sm => sm.Urun)
                .Include(ms => ms.Siparis)
                    .ThenInclude(s => s.Durumlars)
                .Where(ms => ms.Siparis.Durumlars.Any(d => d.Ad == 3))
                .ToListAsync();

            return View(durum);
        }
       
    }
}
