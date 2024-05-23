using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewsModel;
using Restaurant.Models;


namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        private SignInManager<AppUser> _signInManager;
      
        public AccountController(UserManager<AppUser> usermanager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
         

        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewsModel model)
        {
            if (ModelState.IsValid)
            {
                //kullanıcının emaili alınır
                var user = await _userManager.FindByEmailAsync(model.Email);



                if (user != null)
                {
                    //aktif kullanıcı varsa ilk çıkış yapılır.
                    await _signInManager.SignOutAsync();


                    //Pasword kontrol edili eğerki beni hatırla seçeneği işaretlenmişse true olarak kullanıcı oturumu kaydedilir.
                    var results = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                    if (results.Succeeded)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        if (User.IsInRole("Mutfak"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Mutfak" });
                        }
                        if (User.IsInRole("Garson"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Garson" });
                        }
                        if (User.IsInRole("Kasa"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Kasa" });
                        }
                        ModelState.AddModelError("", "*Lütfen Yöneticiniz İle Görüşünüz");

                    }
                    else
                    {

                        ModelState.AddModelError("", "*Parola Yanlış");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "*Bu Email Adresi İle Bir Hesap Bulunumadı");
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()

        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}


