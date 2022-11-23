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
            AdminViewModel viewModel = new AdminViewModel();
            List<AdminLevelModel> adminLevels = _repository.getAllLevel();
            List<AdminViewModel> adminViewModels = new List<AdminViewModel>();
            var result = _adminRepository.FindAllUsers();
            foreach(var item in result)
            {
                viewModel.Email = item.Email;
                viewModel.Name = item.Name;
                viewModel.AdminLevelName = item.AdminLevelName;
                adminViewModels.Add(viewModel);
            }
            viewModel.Level = adminLevels;
            return View(adminViewModels);
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
