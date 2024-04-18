using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MasaController : Controller
    {

        private readonly IdentityDataContext _context;

        public MasaController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MasaEkle(int id)
        {
            if (id == 0)
            {
                ViewBag.Kategoriler = await _context.Kategoriler.Where(x => x.Gorunurluk == true && x.Tur == "Masa").Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Kategoriler = await _context.Kategoriler.Where(x => x.Gorunurluk == true && x.Tur == "Masa").Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();

                 var masa = await _context.Masalar.FirstOrDefaultAsync(x => x.Id == id);
                 return View(masa);
            }
        }

        [HttpPost]
        public async Task<IActionResult> MasaEkle(Masa model, int id)
        {

            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Masalar.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MasaListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("MasaListele");
                }
            }
            else
            {
                ViewBag.Kategoriler = new SelectList(await _context.Kategoriler.ToListAsync(), "Id", "KategoriAd");
                return View(model);
            }
        }
        public async Task<IActionResult> MasaListele()
        {
            var masa = await _context.Masalar.Where(p => p.Gorunurluk == true).ToListAsync();
            ViewBag.Kategoriler = new SelectList(await _context.Kategoriler.ToListAsync(), "Id", "KategoriAd");
            return View(masa);
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
