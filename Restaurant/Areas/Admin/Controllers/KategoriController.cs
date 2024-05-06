using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class KategoriController : Controller
    {

        private readonly IdentityDataContext _context;

        public KategoriController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> KategoriEkle(int id)
        {
            var kategori = await _context.Kategoriler.FirstOrDefaultAsync(x => x.Id == id);
            return View(kategori);

        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle(Kategori model, int id)
        {

            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Kategoriler.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";

                    return RedirectToAction("KategoriListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";

                    return RedirectToAction("KategoriListele");
                }
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> KategoriListele()
        {
            var kategori = await _context.Kategoriler.Where(p => p.Gorunurluk == true).ToListAsync();
            return View(kategori);
        }

        public async Task<IActionResult> Sil(int id)
        {
            var kategori = _context.Kategoriler.FirstOrDefault(x => x.Id == id);

            if (kategori != null)
            {
                kategori.Gorunurluk = false;
                _context.Kategoriler.Update(kategori);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("KategoriListele");
        }
    }
}
