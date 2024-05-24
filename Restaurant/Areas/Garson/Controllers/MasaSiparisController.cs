using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Garson.Controllers
{
    [Area("Garson")]
    [Authorize(Roles = "Garson")]

    public class MasaSiparisController : Controller
    {
        private readonly IdentityDataContext _context;

        public MasaSiparisController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var masasiparisler = _context.MasaSiparisler
                                    .Include(m => m.Masa)
                                    .Include(s => s.Siparis)
                                    .ThenInclude(a => a.SiparisMenuler)
                                    .ThenInclude(sm => sm.Menu)
                                    .Include(s => s.Siparis)
                                    .ThenInclude(z => z.SiparisUrunler)
                                    .ThenInclude(sm => sm.Urun)
                                    .ToList();
            return View(masasiparisler);
        }

        


        public IActionResult MutfakSiparisOnayla()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MutfakSiparisOnayla(int id)
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
                Ad = 2,
                Zaman = DateTime.Now,
                Yer = 2,
            };

            _context.Durumlar.Add(durum);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
