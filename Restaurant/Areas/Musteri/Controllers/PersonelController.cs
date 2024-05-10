using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class PersonelController : Controller
    {
        private readonly IdentityDataContext _context;

        public PersonelController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var personel = await _context.Personeller.Include(x => x.Rol).Where(p => p.Gorunurluk == true).ToListAsync();
            return View(personel);
        }
    }
}
