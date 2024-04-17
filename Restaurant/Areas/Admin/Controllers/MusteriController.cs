using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MusteriController : Controller
    {
        private readonly IdentityDataContext _context;

        public MusteriController(IdentityDataContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MusteriListele()
        {
            var musteri = await _context.Musteriler.Where(p => p.Gorunurluk == true).ToListAsync();
            return View(musteri);
        }
    }
}
