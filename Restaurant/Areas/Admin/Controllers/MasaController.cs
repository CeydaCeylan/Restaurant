using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using System.Runtime.ConstrainedExecution;

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
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("MasaListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";

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

            ViewBag.Ozellikler = await _context.Ozellikler.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Ad
            }).ToListAsync();
            var masa = await _context.Masalar
                               .Include(m => m.MasaOzellikler)
                               .ThenInclude(muhammed => muhammed.Ozellik)
                               .Where(p => p.Gorunurluk == true)
                               .ToListAsync();
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
        public async Task<IActionResult> OzellikEkle(int id)
        {
            var ozellik = await _context.Ozellikler.FirstOrDefaultAsync(x => x.Id == id);
            return View(ozellik);
        }

        [HttpPost]
        public async Task<IActionResult> OzellikEkle(Ozellik model, int id)
        {
            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Ozellikler.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("OzellikListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("OzellikListele");
                }
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> OzellikListele()
        {
            var ozellikler = await _context.Ozellikler.Where(p => p.Gorunurluk == true).ToListAsync();
            //Öncelikle, her bir özelliğe ait masa sayısını hesaplamak için bir dictionary oluşturulur..Bu dictionary, özellik ID'sini anahtar olarak ve o özelliğe ait masa sayısını değer olarak içerecek şekilde tanımlanır.

            Dictionary<int, int> masaSayilari = new Dictionary<int, int>();

            //Özellik listesi döngüsünde, her bir özelliğin ID'sini kullanarak ilgili masaları sayın ve bu sayıyı dictionary'e eklenir.
            foreach (var ozellik in ozellikler)
            {
                int masaSayisi = await _context.MasaOzellikler.CountAsync(mo => mo.OzellikId == ozellik.Id);
                masaSayilari.Add(ozellik.Id, masaSayisi);
            }

            ViewBag.MasaSayilari = masaSayilari;

            return View(ozellikler);
        }

        public async Task<IActionResult> OzellikSil(int id)
        {
            var ozellik = _context.Ozellikler.FirstOrDefault(x => x.Id == id);

            if (ozellik != null)
            {
                ozellik.Gorunurluk = false;
                _context.Ozellikler.Update(ozellik);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("OzellikListele");
        }
        public async Task<IActionResult> MasaOzellikListele()
        {


           var masaozellik = await _context.MasaOzellikler
                                               .Include(m => m.Masa)
                                               .Include(muhammed => muhammed.Ozellik)
                .Where(p => p.Gorunurluk == true).ToListAsync();
                               
            return View(masaozellik);
        }

        public async Task<IActionResult> MasaOzellikSil(int id)
        {
            var masaozellik = _context.MasaOzellikler.FirstOrDefault(x => x.Id == id);

            if (masaozellik != null)
            {
                masaozellik.Gorunurluk = false;
                _context.MasaOzellikler.Update(masaozellik);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MasaOzellikListele");
        }

        [HttpPost]
        public async Task<IActionResult> MasaOzellikAta(int masaid, List<int> ozellikid)
        {
            try
            {
                // Her seçilen özellik için yeni bir MasaOzellik kaydı oluşturun
                foreach (var ozellikId in ozellikid)
                {
                    var masaozellik = new MasaOzellik
                    {
                        MasaId = masaid,
                        OzellikId = ozellikId,
                        Gorunurluk = true,
                    };
                    await _context.MasaOzellikler.AddAsync(masaozellik);
                }

                // Değişiklikleri veritabanına kaydedin
                await _context.SaveChangesAsync();

                // Başarılı bir şekilde özellikler atanmışsa, başlangıç sayfasına yönlendirin veya isteğe bağlı olarak bir başarı mesajı gösterin
                TempData["success"] = "Masa özellikleri başarıyla atanmıştır.";
                return RedirectToAction(nameof(MasaListele));
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler...
                TempData["error"] = "Masa özellikleri atanırken bir hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(MasaListele)); // veya isteğe bağlı olarak hata mesajı gösterin
            }
        }


        public async Task<IActionResult> MasaSil(int id)
        {
            var masa = _context.Masalar.FirstOrDefault(x => x.Id == id);

            if (masa != null)
            {
                masa.Gorunurluk = false;
                _context.Masalar.Update(masa);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MasaListele");
        }
    }
}
