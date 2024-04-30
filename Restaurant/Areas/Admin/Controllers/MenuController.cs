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
                    return RedirectToAction("MenuListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
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
        public async Task<IActionResult> MenuUrunEkle()
        {
            var urun = await _context.Urunler
                .Where(p => p.Gorunurluk == true)
                .ToListAsync();
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


    }
}
