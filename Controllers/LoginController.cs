using AtlasControl.Helpers;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AtlasControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminRepository _repository;
        public LoginController(IAdminRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(AdminModel admin)
        {
            var adminLevelName = "";
            CryptographyHelper crypto = new CryptographyHelper(SHA256.Create());
            admin.Password = crypto.hashPassword(admin.Password);
            var result = _repository.FindUser(admin);
            foreach(var item in result)
            {
                adminLevelName = item.AdminLevelName;
            }
            if (result != null)
            {
                HttpContext.Session.SetString("adminLevel", adminLevelName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }
    }
}
