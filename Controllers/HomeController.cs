using AtlasControl.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AtlasControl.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Exit()
        {
            if(HttpContext.Session.GetString("user") != null)
            {
                HttpContext.Session.Remove("user");
            }
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}