using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class YorumController : Controller
    {

        private readonly IdentityDataContext _context;

        public YorumController(IdentityDataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var yorum = await _context.Yorumlar.Where(p => p.Gorunurluk == true).ToListAsync();
            return View(yorum);
        }
    }
}
