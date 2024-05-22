using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Restaurant.Areas.Musteri.Models;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.ViewsModel;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class SepetController : Controller
    {
        private readonly IdentityDataContext _context;

        public SepetController(IdentityDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menuler
                .Include(m => m.Kategori)
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();


            var uruns = await _context.Urunler
                .Include(m => m.Kategori)
                .Where(m => m.Gorunurluk == true)
                .ToListAsync();

            return View(menus);
        }

        public async Task<IActionResult> MenuSepet(int id)
        {
            var menu = await _context.Menuler
                .FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            var menus = new menusepetmodel
            {
                Ad = menu.Ad,
                Aciklama = menu.Aciklama,
                Id = id,
                Fotograf = menu.Fotograf,
                Fiyat = menu.Fiyat,
                IndirimliFiyat = menu.IndirimliFiyat,
                IndirimTarihi = menu.IndirimTarihi,
                Tur = 1
            };
            return Json(menus);
        }

        public async Task<IActionResult> UrunSepet(int id)
        {
            var urun = await _context.Urunler
                .FirstOrDefaultAsync(x => x.Id == id);
            if (urun == null)
            {
                return NotFound();
            }
            var urunsepeti = new urunsepetmodel
            {
                Ad = urun.Ad,
                Acıklama = urun.Acıklama,
                Id = id,
                Fotograf = urun.Fotograf,
                Fiyat = urun.Fiyat,
                IndirimliFiyat = urun.IndirimliFiyat,
                IndirimTarihi = urun.IndirimTarihi,
                Tur = 2
            };

            return Json(urunsepeti);
        }

        public async Task<IActionResult> SiparisVer(string sepet, string masaKodu, int id)
        {
            var siparisArray = JsonConvert.DeserializeObject<List<MasaSiparisViewsModel>>(sepet);
            var masa = await _context.Masalar
               .FirstOrDefaultAsync(m => m.Kod == masaKodu);

            var Siparis = new Siparis
            {
              Gorunurluk = true,

            };
            _context.Siparisler.Add(Siparis);          
            var masaSiparis = new MasaSiparis
            {
                Masa = masa,
                Siparis = Siparis,
                Tutar = 0
            };

            _context.MasaSiparisler.Add(masaSiparis);

            foreach (var item in siparisArray)
            {
                if (item.tur == 1)
                {
                    var menu = await _context.Menuler.FindAsync(item.id);
                    if (menu == null)
                    {
                        BadRequest("Menü Boş.");
                    }
                    var fiyat = menu.IndirimliFiyat.HasValue ? menu.IndirimliFiyat.Value : menu.Fiyat;

                    var siparisMenu = new SiparisMenu
                    {
                        Siparis = Siparis,
                        MenuId = menu.Id, 
                        Miktar = item.adet,
                        
                    };
                    masaSiparis.Tutar += (fiyat * item.adet);
                    _context.SiparisMenuler.Add(siparisMenu);
                }
                else if (item.tur == 2)
                {
                    var urun = await _context.Urunler.FindAsync(item.id);
                    if (urun == null)
                    {
                        BadRequest("Ürün Boş.");
                    }
                    var fiyat = urun.IndirimliFiyat.HasValue ? urun.IndirimliFiyat.Value : urun.Fiyat;
                    var siparisUrun = new SiparisUrun
                    {
                        Siparis = Siparis,
                        UrunId = urun.Id,
                        Miktar = item.adet,

                    };
                    masaSiparis.Tutar += (fiyat * item.adet);
                    _context.SiparisUrunler.Add(siparisUrun);
                }
            }               
                _context.SaveChanges();

                return Json(siparisArray);
            }
        }
    }

