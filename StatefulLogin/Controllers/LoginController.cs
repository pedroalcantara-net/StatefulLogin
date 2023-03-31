using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StatefulLogin.ViewModels;

namespace StatefulLogin.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            if (login.Username == "admin" && login.Password == "admin")
            {
                HttpContext.Session.SetString("Username", login.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Usuário ou senha inválidos!";
                return View();
            }
        }

        [HttpGet("Logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
