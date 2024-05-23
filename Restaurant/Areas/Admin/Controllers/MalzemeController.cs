using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class MalzemeController : Controller
    {

        private readonly IdentityDataContext _context;

        public MalzemeController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MalzemeEkle(int id)
        {
            if (id == 0)
            {
                ViewBag.Tedarikciler = await _context.Tedarikciler.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Firma
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Tedarikciler = await _context.Tedarikciler.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Firma
                }).ToListAsync();

                var malzeme = await _context.Malzemeler.FirstOrDefaultAsync(x => x.Id == id);
                return View(malzeme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> MalzemeEkle(Malzeme model, int id)
        {

            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Malzemeler.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("MalzemeListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("MalzemeListele");
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> MalzemeListele()
        {

            var malzeme = await _context.Malzemeler
                .Include(x => x.Stok)
                .ThenInclude(x => x.Tedarikci)
                .Where(p => p.Gorunurluk == true).ToListAsync();

            return View(malzeme);

        }

        public async Task<IActionResult> Sil(int id)
        {
            var malzeme = _context.Malzemeler.FirstOrDefault(x => x.Id == id);

            if (malzeme != null)
            {
                malzeme.Gorunurluk = false;
                _context.Malzemeler.Update(malzeme);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MalzemeListele");
        }

        public async Task<IActionResult> StokGirdi(int id)
        {
            if (id == 0)
            {
                ViewBag.Malzemeler = await _context.Malzemeler.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Malzemeler = await _context.Malzemeler.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();

                var malzeme = await _context.Malzemeler.FirstOrDefaultAsync(x => x.Id == id);
                return View(malzeme);
            }
        }
        [HttpPost]
        public async Task<IActionResult> StokGirdi(StokGirdi model, int id)
        {
            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    var tedarik = await _context.Malzemeler
                                    .Include(muhammed => muhammed.Stok)
                                    .ThenInclude(enes => enes.Tedarikci)
                                    .FirstOrDefaultAsync(x => x.Id == model.MalzemeId);

                    if (tedarik != null)
                    {
                        tedarik.Stok.Miktar += model.Miktar;
                        _context.Update(tedarik.Stok);
                    }
                    model.TedarikciId = tedarik.Stok.TedarikciId;
                    _context.StokGirdiler.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("StokGirdiListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("StokGirdiListele");
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> StokGirdiListele()
        {
            var stokgirdi = await _context.StokGirdiler
         .Where(p => p.Gorunurluk == true)
         .Include(p => p.Malzeme)
         .Include(p => p.Tedarikci)
         .ToListAsync();

            return View(stokgirdi);
        }


        public async Task<IActionResult> StokCikti(int id)
        {
            if (id == 0)
            {
                ViewBag.Malzemeler = await _context.Malzemeler.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Malzemeler = await _context.Malzemeler.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();

                var malzeme = await _context.Malzemeler.FirstOrDefaultAsync(x => x.Id == id);
                return View(malzeme);
            }
        }

        [HttpPost]
        public async Task<IActionResult> StokCikti(StokCikti model, int id)
        {
            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    var tedarik = await _context.Malzemeler
                                    .Include(muhammed => muhammed.Stok)
                                    .ThenInclude(enes => enes.Tedarikci)
                                    .FirstOrDefaultAsync(x => x.Id == model.MalzemeId);

                    if (tedarik != null)
                    {
                        tedarik.Stok.Miktar -= model.Miktar;
                        _context.Update(tedarik.Stok);
                    }
                    model.TedarikciId = tedarik.Stok.TedarikciId;
                    _context.StokCiktilar.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("StokCiktiListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("StokCiktiListele");
                }
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> StokCiktiListele()
        {
            var stokcikti = await _context.StokCiktilar
         .Where(p => p.Gorunurluk == true)
         .Include(p => p.Malzeme)
         .Include(p => p.Tedarikci)
         .ToListAsync();

            return View(stokcikti);
        }
    }

}
