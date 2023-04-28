using AtlasControl.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtlasControl.Controllers
{
    public class DenounceController : Controller
    {
        private readonly IDenounceRepository _repository;
        public DenounceController(IDenounceRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var result = _repository.GetAllDenounces();
            return View(result);
        }
    }
}
