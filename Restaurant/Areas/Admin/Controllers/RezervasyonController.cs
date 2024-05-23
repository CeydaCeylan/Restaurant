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

    public class RezervasyonController : Controller
    {
        private readonly IdentityDataContext _context;

        public RezervasyonController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> RezervasyonEkle(int id)
        {
            if (id == 0)
            {
                ViewBag.Masalar = await _context.Masalar.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Kod
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Masalar = await _context.Masalar.Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Kod
                }).ToListAsync();

                var masarezervasyon = await _context.Rezervasyonlar.Include(x => x.MasaRezervasyonlar).FirstOrDefaultAsync(x => x.Id == id);
                foreach (var item in masarezervasyon.MasaRezervasyonlar)
                {
                    return View(item);
                }
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RezervasyonEkle(MasaRezervasyon model, List<int> MasaId, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {

                    foreach (var masaa in MasaId)
                    {
                        MasaRezervasyon masarez = new MasaRezervasyon
                        {
                            MasaId = masaa,
                            Rezervasyon = model.Rezervasyon,
                            Gorunurluk = true,
                        };
                        await _context.MasaRezervasyonlar.AddAsync(masarez);
                    }
                    model.Rezervasyon.Gorunurluk = true;
                    _context.Rezervasyonlar.Add(model.Rezervasyon);

                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("RezervasyonListele");
                }
                else
                {
                    var rezervasyon = await _context.Rezervasyonlar
                                .Include(x=>x.MasaRezervasyonlar)
                                .FirstOrDefaultAsync(x => x.Id == id);


                    rezervasyon.Talep = model.Rezervasyon.Talep;
                    rezervasyon.Tarih = model.Rezervasyon.Tarih;
                    rezervasyon.KisiSayisi = model.Rezervasyon.KisiSayisi;
                    rezervasyon.BitisSaat = model.Rezervasyon.BitisSaat;
                    rezervasyon.BaslangicSaat = model.Rezervasyon.BaslangicSaat;
                    rezervasyon.Onay = model.Rezervasyon.Onay;
                    rezervasyon.TalepTarihi = model.Rezervasyon.TalepTarihi;

                    foreach (var item in rezervasyon.MasaRezervasyonlar.Where(x => x.Gorunurluk == true))
                    {
                        if(MasaId.Contains((int)(item.MasaId)))
                        {
                            item.Gorunurluk = true;
                            await _context.MasaRezervasyonlar.AddAsync(item);
                        }
                        else
                        {
                            foreach (var masaa in MasaId)
                            {
                                MasaRezervasyon masarez = new MasaRezervasyon
                                {
                                    MasaId = masaa,
                                    Rezervasyon = model.Rezervasyon,
                                    Gorunurluk = true,
                                };
                                await _context.MasaRezervasyonlar.AddAsync(masarez);
                            }
                        }
                    }
                    _context.Rezervasyonlar.Update(rezervasyon);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("RezervasyonListele");
                }
            }
            else
            {
                ViewBag.Masalar = new SelectList(await _context.Masalar.ToListAsync(), "Id", "MasaKod");
                return View(model);
            }
        }
        public async Task<IActionResult> RezervasyonListele()
        {
            var masarezervasyon = await _context.Rezervasyonlar
                .Include(x => x.MasaRezervasyonlar)
                .ThenInclude(x => x.Masa)
                .Where(p => p.Gorunurluk == true)
                .ToListAsync();

            return View(masarezervasyon);
        }

        public async Task<IActionResult> Sil(int id)
        {
            var rezervasyon = _context.Rezervasyonlar
                .Include(x => x.MasaRezervasyonlar)
                .FirstOrDefault(x => x.Id == id);

            if (rezervasyon == null)
            {
                return NotFound();
            }

            rezervasyon.Gorunurluk = false;

            foreach (var item in rezervasyon.MasaRezervasyonlar)
            {
                item.Gorunurluk = false;
            }


            _context.Rezervasyonlar.Update(rezervasyon);
            await _context.SaveChangesAsync();


            return RedirectToAction("RezervasyonListele");
        }

        public IActionResult RezervasyonTakvim()
        {
            return View();
        }

    }
}