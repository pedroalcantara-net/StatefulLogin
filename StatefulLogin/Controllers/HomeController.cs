using Microsoft.AspNetCore.Mvc;

namespace StatefulLogin.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
        }
    }
}
