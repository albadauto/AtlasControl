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
            CryptographyHelper crypto = new CryptographyHelper(SHA256.Create());
            AdminViewModel adm = new AdminViewModel();
            admin.Password = crypto.hashPassword(admin.Password);
            var result = _repository.FindUser(admin);
            
            foreach (var item in result)
            {
               adm.AdminLevelName = item.AdminLevelName;
               adm.Email = item.Email;
               adm.Name = item.Name;
            }
            if (result != null)
            {
                HttpContext.Session.SetString("adminLevel", adm.AdminLevelName);
                HttpContext.Session.SetString("email", adm.Email);
                HttpContext.Session.SetString("name", adm.Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }
    }
}
