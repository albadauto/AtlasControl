using Microsoft.AspNetCore.Mvc;

namespace AtlasControl.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("user", "admin");
            return RedirectToAction("Index", "Home");
        }
    }
}
