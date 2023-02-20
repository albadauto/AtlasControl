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

            foreach (var item in result)
            {
                adminViewModels.Add(new AdminViewModel() {
                    Email = item.Email,
                    AdminLevelName = item.AdminLevelName, 
                    Name = item.Name, 
                    Admin = new AdminModel() { Id = item.Admin.Id } });
            }

            return View(adminViewModels);
        }

        public IActionResult CreateNewUser()
        {
            AdminViewModel allLevel = new AdminViewModel() { Level = _repository.getAllLevel() };
            return View(allLevel);
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

        public IActionResult RemoveNewUser(int id)
        {
            _adminRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}
