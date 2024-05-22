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
                Id = id,
            };

            foreach (var item in siparisArray)
            {
                if (item.tur == 1)
                {
                    var siparisMenu = new SiparisMenu
                    {
                        SiparisId = Siparis.Id,
                        MenuId = item.id, // item'dan MenuId alıyoruz
                        Miktar = item.adet
                    };

                    _context.SiparisMenuler.Add(siparisMenu);
                }
                else if (item.tur == 2)
                {
                    var siparisUrun = new SiparisUrun
                    {
                        SiparisId = Siparis.Id,
                        UrunId = item.id,
                        Miktar = item.adet
                    };

                    _context.SiparisUrunler.Add(siparisUrun);
                }
            }
                var masaSiparis = new MasaSiparis
                {
                    Masa = masa,
                    Siparis = Siparis,
                };

                _context.MasaSiparisler.Add(masaSiparis);
                _context.SaveChanges();

                return Json(siparisArray);
            }
        }
    }

