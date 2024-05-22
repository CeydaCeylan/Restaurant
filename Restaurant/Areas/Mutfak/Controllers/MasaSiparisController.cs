using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Mutfak.Controllers
{

    [Area("Mutfak")]
    public class MasaSiparisController : Controller
    {
        public IActionResult Onayla()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Onayla(int MasaSiparisId, string MasaKodu, string SiparisDetaylari, string ToplamTutar)
        {
            
            return RedirectToAction("Index"); 
        }
    }
}
