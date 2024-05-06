using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Restaurant.Areas.Admin.ViewModel;
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

        public async Task<IActionResult> UrunEkle(int id)
        {
            if (id == 0)
            {
                ViewBag.Kategoriler = await _context.Kategoriler.Where(x => x.Gorunurluk == true && x.Tur == "Urun").Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Kategoriler = await _context.Kategoriler.Where(x => x.Gorunurluk == true && x.Tur == "Urun").Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();

                var urun = await _context.Urunler.FirstOrDefaultAsync(x => x.Id == id);
                return View(urun);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("UrunFotograf", "Geçerli bir resim seçiniz. *jpg,jpeg,png");
                        return View(model);
                    }

                    var random = string.Format($"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}");
                    var resimyolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", random);
                    using (var stream = new FileStream(resimyolu, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    model.Fotograf = random;

                }
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Urunler.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("UrunListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("UrunListele");
                }
            }
            else
            {
                ViewBag.Kategoriler = new SelectList(await _context.Kategoriler.ToListAsync(), "Id", "KategoriAd");
                return View(model);
            }
        }

        public async Task<ActionResult> UrunListele()
        {
            var urunler = await _context.Urunler
                                .Include(u => u.Kategori)
                                .Where(u => u.Gorunurluk == true)
                                .ToListAsync();

            var urunMalzemeAdlari = new Dictionary<int, List<string>>();

            foreach (var urun in urunler)
            {
                var malzemeAdlari = await _context.UrunMalzemeler
                                                .Where(um => um.UrunId == urun.Id)
                                                .Select(um => um.Malzeme.Ad)
                                                .ToListAsync();

                urunMalzemeAdlari.Add(urun.Id, malzemeAdlari);
            }

            ViewBag.UrunMalzemeAdlari = urunMalzemeAdlari;

            return View(urunler);
        }

        public async Task<IActionResult> MalzemeEkle(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzemeler
                .Include(x => x.Stok)
                .ThenInclude(x => x.Tedarikci)
                .Where(p => p.Gorunurluk == true).ToListAsync();

            // Ürünün daha önceden seçilmiş malzemelerini al
            var seciliMalzemeler = await _context.UrunMalzemeler
                                                .Where(um => um.UrunId == id)
                                                .Select(um => um.MalzemeId)
                                                .ToListAsync();

            ViewBag.SeciliMalzemeler = seciliMalzemeler;

            return View(malzeme);
        }

        [HttpPost]
        public async Task<IActionResult> MalzemeEkle(int id, string malzemeler)
        {
            var itemList = JsonConvert.DeserializeObject<List<ItemModel>>(malzemeler);
            if (itemList == null)
            {
                return NotFound();
            }

            foreach (var item in itemList)
            {
                var urunmalzem = new UrunMalzeme
                {
                    UrunId = id,
                    MalzemeId = int.Parse(item.Id),
                    Miktar = int.Parse(item.Miktar),
                };
                _context.UrunMalzemeler.Add(urunmalzem);
            }
            _context.SaveChanges();
            return RedirectToAction("UrunListele");
        }

        public async Task<IActionResult> Sil(int id)
        {
            var urun = _context.Urunler.FirstOrDefault(x => x.Id == id);

            if (urun != null)
            {
                urun.Gorunurluk = false;
                _context.Urunler.Update(urun);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("UrunListele");
        }
    }
}