using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {

        private readonly IdentityDataContext _context;

        public UrunController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun model)
        {
            if (ModelState.IsValid)
            {
                _context.Urunler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("UrunListele");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult UrunListele()
        {
            return View();
        }
    }
}
