using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MalzemeController : Controller
    {

        private readonly IdentityDataContext _context;

        public MalzemeController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MalzemeEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MalzemeEkle(Malzeme model, int id)
        {

            if (ModelState.IsValid)
            {
                model.Gorunurluk = true;

                if (id == 0)
                {

                    _context.Malzemeler.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MalzemeListele");
                }

                else
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("MalzemeListele");
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> MalzemeListele()
        {

            var malzeme = await _context.Malzemeler.Where(p => p.Gorunurluk == true).ToListAsync();
            return View(malzeme);

        }

        public async Task<IActionResult> Sil(int id)
        {
            var malzeme = _context.Malzemeler.FirstOrDefault(x => x.Id == id);

            if (malzeme != null)
            {
                malzeme.Gorunurluk = false;
                _context.Malzemeler.Update(malzeme);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MalzemeListele");
        }
    }
}
