using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PersonelController : Controller
    {
        private readonly IdentityDataContext _context;

        public PersonelController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> PersonelEkle(int id)
        {
            if (id == 0)
            {
                ViewBag.Roller = await _context.Roller.Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Ad
                }).ToListAsync();
                return View();
            }
            else
            {
                ViewBag.Roller = await _context.Roller.Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Ad
                }).ToListAsync();
                var personel = await _context.Personeller.FirstOrDefaultAsync(x => x.Id == id);
                return View(personel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle(Personel model, int id, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var rol = await _context.Roller.FirstOrDefaultAsync(x => x.Id == model.RolId);
                if (rol != null)
                {
                    model.RolId = rol.Id;
                    model.Rol = rol;
                }

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

                    model.PersonelFotograf = random;
                }

                model.Gorunurluk = true;

                if (id == 0)
                {
                    _context.Personeller.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("PersonelListele");
                }
                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("PersonelListele");
                }

            }
            else
            {
                ViewBag.Roller = new SelectList(await _context.Roller.ToListAsync(), "Id", "RolAd");
                return View(model);
            }

        }
        public async Task<IActionResult> RolEkle(int id)
        {
            var rol = await _context.Roller.FirstOrDefaultAsync(x => x.Id == id);
            return View(rol);
        }

        public async Task<IActionResult> RolDetay(int id)
        {
            var rol = await _context.Roller
                     .FindAsync(id);
            var personel = await _context.Personeller.Where(x => x.RolId == id)
                .ToListAsync();
            return View(personel);

        }

        [HttpPost]
        public async Task<IActionResult> RolEkle(Rol model, int id)
        {
            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Roller.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Kayıt eklendi.";
                    return RedirectToAction("RolListe");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    TempData["success"] = "Kayıt güncellendi.";
                    return RedirectToAction("RolListe");
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> RolListe(int id)
        {
            var rol = await _context.Roller
                     .Where(r => r.Gorunurluk == true)
                     .Include(f => f.Personellers)
                     .ToListAsync();
            var roller = rol.FirstOrDefault(x => x.Id == id);

            return View(rol);
        }

        public async Task<IActionResult> RolSil(int id)
        {
            var rol = _context.Roller.FirstOrDefault(x => x.Id == id);

            if (rol != null)
            {
                var personelRolleri = await _context.Personeller.Where(p => p.RolId == id).ToListAsync();             

                rol.Gorunurluk = false;
                _context.Roller.Update(rol);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("RolListe");
        }

        public async Task<IActionResult> PersonelListele()
        {

            var personel = await _context.Personeller.Include(x => x.Rol).Where(p => p.Gorunurluk == true).ToListAsync();
            return View(personel);

        }

        public async Task<IActionResult> Sil(int id)
        {
            var personel = _context.Personeller.FirstOrDefault(x => x.Id == id);

            if (personel != null)
            {
                personel.Gorunurluk = false;
                _context.Personeller.Update(personel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("PersonelListele");
        }
    }
}
