using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PersonelController : Controller
    {
        private readonly IdentityDataContext _context;

        public PersonelController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
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

                    model.PersonelFotograf = file.FileName;
                }

                _context.Personeller.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("PersonelListele");
            }
            else
            {
                ViewBag.Roller = new SelectList(await _context.Roller.ToListAsync(), "Id", "RolAd");
                return View(model);
            }

        }
        public IActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RolEkle(Rol model)
        {
            if (ModelState.IsValid)
            {
                _context.Roller.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("RolListe");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult RolListe()
        {
            var rol = _context.Roller.ToList();

            return View(rol);
        }

        public async Task<IActionResult> PersonelListele()
        {

            var personel = _context.Personeller.ToList();
            ViewBag.Roller = new SelectList(await _context.Roller.ToListAsync(), "Id", "RolAd");

            return View(personel);

        }
    }
}
