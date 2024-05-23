using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    }
}
