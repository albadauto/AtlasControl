﻿using AtlasControl.Helpers;
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
            if (admin.Email == null || admin.Password == null) return RedirectToAction("Index");
            CryptographyHelper crypto = new CryptographyHelper(SHA256.Create());
            AdminViewModel adm = new AdminViewModel();
            admin.Password = crypto.hashPassword(admin.Password);
            var result = _repository.FindUser(admin);
            foreach (var item in result)
            {
               adm.AdminLevelName = item.AdminLevelName;
               adm.Email = item.Email;
               adm.Name = item.Name;
               adm.Password = item.Password;
            }
            if (adm.Email != null && adm.Password != null)
            {
                HttpContext.Session.SetString("adminLevel", adm.AdminLevelName);
                HttpContext.Session.SetString("email", adm.Email);
                HttpContext.Session.SetString("name", adm.Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["loginError"] = "Usuário ou senha inexistentes, por favor, contatar supervisor";
                return RedirectToAction("Index");

            }
        }

        public IActionResult ForTest()
        {
            HttpContext.Session.SetString("name", "José");
            HttpContext.Session.SetString("email", "teste@teste");
            HttpContext.Session.SetString("adminLevel", "SUPERVISOR");
            return RedirectToAction("Index", "Home");
        }
    }
}
