using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Diagnostics;

namespace Restaurant.Controllers
{
	public class HomeController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}


	}
}
