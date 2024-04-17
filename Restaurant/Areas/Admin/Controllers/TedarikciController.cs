﻿using Microsoft.AspNetCore.Mvc;
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
                model.Gorunurluk = true;
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
            var tedarikci = await _context.Tedarikciler.Where(p => p.Gorunurluk == true).ToListAsync();

            return View(tedarikci);

        }

        public async Task<IActionResult> Sil(int id)
        {
            var tedarikci = _context.Tedarikciler.FirstOrDefault(x => x.Id == id);

            if (tedarikci != null)
            {
                tedarikci.Gorunurluk = false;
                _context.Tedarikciler.Update(tedarikci);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("TedarikciListele");
        }
    }
}
