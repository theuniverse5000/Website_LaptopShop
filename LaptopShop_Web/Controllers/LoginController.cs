using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class LoginController : Controller
    {
        HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<IActionResult> CheckLogin()
        {
            return View();

        }
        public async Task<IActionResult> CheckLogin(string username, string password)
        {
            var result = await client.GetFromJsonAsync<bool>($"https://localhost:44308/api/Login/admin/?username={username}&password={password}");
            var r2 = await client.GetFromJsonAsync<bool>($"https://localhost:44308/api/Login/client/?username={username}&password={password}");
            if (result)
            {
                HttpContext.Session.SetString("RoleUser", "admin");
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "Home");
            }
            else if (r2)
            {
                HttpContext.Session.SetString("RoleUser", "client");
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "Home");

            }
            return View();

        }
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("RoleUser");
            HttpContext.Session.Remove("Username");
            return RedirectToAction("CheckLogin", "Login");
        }
    }
}
