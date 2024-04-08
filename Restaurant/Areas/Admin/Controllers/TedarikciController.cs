using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TedarikciController : Controller
    {
        private readonly IdentityDataContext _context;

        public TedarikciController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TedarikciEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TedarikciEkle(Tedarikci model)
        {
            if (ModelState.IsValid)
            {
                _context.Tedarikciler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("TedarikciListele");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> TedarikciListele()
        {
            var tedarikci = _context.Tedarikciler.ToList();
            return View(tedarikci);

        }
    }
}
