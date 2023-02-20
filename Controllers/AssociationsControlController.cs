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
        public IActionResult UpdateAssociation(int idAssociation) 
        {
            try
            {
                _association.SetAssociationToAccept(idAssociation);
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
