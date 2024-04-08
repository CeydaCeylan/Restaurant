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
        public async Task<IActionResult> MalzemeEkle(Malzeme model)
        {
            if (ModelState.IsValid)
            {
                _context.Malzemeler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("MalzemeListele");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> MalzemeListele()
        {
            var malzeme = _context.Malzemeler.ToList();
            return View(malzeme);

        }
    }
}
