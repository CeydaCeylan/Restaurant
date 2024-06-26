﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]

    public class MenuController : Controller
    {
        private readonly IdentityDataContext _context;

        public MenuController(IdentityDataContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MenuEkle(int id)
        {

            if (id == 0)
            {
                ViewBag.Kategoriler = await _context.Kategoriler.Where(x => x.Gorunurluk == true && x.Tur == "Menu").Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Kategoriler = await _context.Kategoriler.Where(x => x.Gorunurluk == true && x.Tur == "Menu").Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }).ToListAsync();

                var menu = await _context.Menuler.FirstOrDefaultAsync(x => x.Id == id);
                return View(menu);
            }


        }

        [HttpPost]
        public async Task<IActionResult> MenuEkle(Menu model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("MenuFotograf", "Geçerli bir resim seçiniz. *jpg,jpeg,png");
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

                    _context.Menuler.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("MenuListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("MenuListele");
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<ActionResult> MenuListele()
        {
            var menuler = await _context.Menuler
                .Include(u => u.Kategori)
                .Where(p => p.Gorunurluk == true)
                .ToListAsync();
      

            var menuUrunlerAdlari = new Dictionary<int, List<string>>();

            foreach (var menu in menuler)
            {
                var urunAdlari = await _context.MenuUrunler
                                                .Where(um => um.MenuId == menu.Id)
                                                .Select(um => um.Urun.Ad)
                                                .ToListAsync();

                menuUrunlerAdlari.Add(menu.Id, urunAdlari);
            }

            ViewBag.menuUrunlerAdlari = menuUrunlerAdlari;

            return View(menuler);
        }

        public async Task<IActionResult> MenuUrunEkle(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .Where(p => p.Gorunurluk == true)
                .ToListAsync();

            // Ürünün daha önceden seçilmiş malzemelerini al
            var seciliUrunler= await _context.MenuUrunler
                                                .Where(um => um.MenuId == id)
                                                .Select(um => um.UrunId)
                                                .ToListAsync();

            ViewBag.seciliUrunler = seciliUrunler;

            return View(urun);
        }

        [HttpPost]
        public async Task<IActionResult> MenuUrunEkle(int id, string urunler)
        {
            var itemList = JsonConvert.DeserializeObject<List<ItemModel>>(urunler);
            if (itemList == null)
            {
                return NotFound();
            }

            foreach (var item in itemList)
            {
                var menurun = new MenuUrun
                {
                    MenuId = id,
                    UrunId = int.Parse(item.Id),
                    Miktar = int.Parse(item.Miktar),
                };
                _context.MenuUrunler.Add(menurun);
            }
            _context.SaveChanges();
            return RedirectToAction("MenuListele");
        }

        public async Task<IActionResult> Sil(int id)
        {
            var menu = _context.Menuler.FirstOrDefault(x => x.Id == id);

            if (menu != null)
            {
                menu.Gorunurluk = false;
                _context.Menuler.Update(menu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MenuListele");
        }
        public async Task<IActionResult> HesaplaIndirimFiyati()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HesaplaIndirimFiyati(int menuId, DateOnly indirimTarihi, string indirimFiyati, string indirimYuzdesi)
        {
            // Veritabanından ürünü al
            var menu = await _context.Menuler.FindAsync(menuId);

            if (menu == null)
            {
                return NotFound(); // Ürün bulunamadıysa NotFound döndür
            }

            if (indirimYuzdesi == "%")
            {
                // Yüzde üzerinden indirim yap
                if (double.TryParse(indirimFiyati, out double indirimYuzdesiDouble))
                {
                    decimal indirimOrani = (decimal)indirimYuzdesiDouble / 100;
                    menu.IndirimliFiyat = menu.Fiyat - (menu.Fiyat * indirimOrani);
                }
            }
            else if (indirimYuzdesi == "-")
            {
                // Sabit fiyat üzerinden indirim yap
                if (double.TryParse(indirimFiyati, out double indirimFiyatiDouble))
                {
                    menu.IndirimliFiyat = menu.Fiyat - (decimal)indirimFiyatiDouble;
                }
            }
            else
            {
                return BadRequest(); // Geçersiz indirim türü
            }

            // İndirim bitiş tarihini atama
            menu.IndirimTarihi = indirimTarihi;

            _context.Menuler.Update(menu);
            await _context.SaveChangesAsync();

            return RedirectToAction("MenuListele"); // Ürünlerin listesine geri dön
        }


    }
}
