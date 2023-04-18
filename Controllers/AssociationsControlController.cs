using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtlasControl.Controllers
{
    public class AssociationsControlController : Controller
    {
        private readonly IAssociationRepository _association;
        public AssociationsControlController(IAssociationRepository association)
        {
            _association = association;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null ) return RedirectToAction("Index", "Login");
            var result = _association.GetAllAssociations();
            return View(result);
        }

        [HttpGet]
        public IActionResult UpdateAssociation(int id) 
        {
            try
            {
                _association.SetAssociationToAccept(id);
                TempData["successAssociation"] = "Usuário aprovado para avaliação";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        
        }
    }
}
