using BL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();

        public IActionResult Index()
        {
            TempData["ReturnUrl"] = HttpContext.Request.Query["ReturnUrl"];

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password, string ReturnUrl)
        {
            try
            {
                var account = userManager.Get(a => a.Email == email && a.Password == password && a.IsActive == true);

                if (account == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bulunamadı!");
                    TempData["MessageAccount"] = "Kullanıcı Bulunamadı!";
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, email),
                    };

                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction("Index", "Default");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu! Kullanıcı Bulunamadı!");
                TempData["MessageAccount"] = "Hata Oluştu! Kullanıcı Bulunamadı!";
            }

            return View();
        }

        [Route("Admin/Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }

    }
}
