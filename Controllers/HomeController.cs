using AtlasControl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace AtlasControl.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Exit()
        {
            if(HttpContext.Session.GetString("adminLevel") != null)
            {
                HttpContext.Session.Remove("adminLevel");
                HttpContext.Session.Remove("email");
                HttpContext.Session.Remove("name");
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