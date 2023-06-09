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
            if (HttpContext.Session.GetString("email") == null)
                return RedirectToAction("Index", "Login");
            var result = _repository.GetAllDenounces();
            return View(result);
        }

        [HttpGet]
        public IActionResult DeleteDenounce(int Id) 
        {
            try
            {
                var result = _repository.RemoveDenounce(Id);
                if (result)
                {
                    TempData["successDenounce"] = "Denúncia despachada com sucesso";
                }
                else
                {
                    TempData["errorDenounce"] = "Erro: Contatar um administrador";

                }
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }
    }
}
