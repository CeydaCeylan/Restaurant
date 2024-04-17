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
        public async Task<IActionResult> UrunEkle(Urun model,int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var uzanti = new[] { ".jpg", ".jpeg", ".png" };
                    var resimuzanti = Path.GetExtension(file.FileName);
                    if (!uzanti.Contains(resimuzanti))
                    {
                        ModelState.AddModelError("OgrenciFotograf", "Geçerli bir resim seçiniz. *jpg,jpeg,png");
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
                    return RedirectToAction("UrunListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("UrunListele");
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<ActionResult> UrunListele()
        {
            var urun = await _context.Urunler.Where(p => p.Gorunurluk == true).ToListAsync();
            return View(urun);
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

        public IActionResult Incele()
        { 
            return View(); 
        }
    }
}
