﻿using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class MenuController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MenuEkle()
        {
            return View();
        }

        public IActionResult MenuListele()
        {
            return View();
        }
    }
}
