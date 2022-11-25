using AtlasControl.Helpers;
using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AtlasControl.Controllers
{
    public class UserControlController : Controller
    {
        private readonly IAdminLevelRepository _repository;
        private readonly IAdminRepository _adminRepository;
        public UserControlController(IAdminLevelRepository repository, IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            _repository = repository;
        }
        public IActionResult Index()
        {
            List<AdminViewModel> adminViewModels = new List<AdminViewModel>();
            var result = _adminRepository.FindAllUsers();
            var all = _repository.getAllLevel();

            foreach (var item in result)
            {
                adminViewModels.Add(new AdminViewModel() {
                    Email = item.Email,
                    AdminLevelName = item.AdminLevelName, 
                    Name = item.Name, 
                    Admin = new AdminModel() });
            }

            return View(adminViewModels);
        }

        public IActionResult CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertNewUser(AdminModel admin)
        {
            CryptographyHelper crypt = new CryptographyHelper(SHA256.Create());
            admin.Password = crypt.hashPassword(admin.Password);
            _adminRepository.InsertUser(admin);
            TempData["success"] = "Novo usuário inserido com sucesso!";
            return RedirectToAction("Index", "UserControl");
        }


    }
}
