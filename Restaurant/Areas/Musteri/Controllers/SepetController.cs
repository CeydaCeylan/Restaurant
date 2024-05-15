using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> MenuSepet(int id)
        {
            var menu = await _context.Menuler
                .FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            return Json(menu);
        }
    }
}
