using AtlasControl.Models;
using AtlasControl.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtlasControl.Controllers
{
    public class AssociationsControlController : Controller
    {
        private readonly IAssociationRepository _association;
        private readonly IDocumentationRepository _documentation;
        public AssociationsControlController(IAssociationRepository association, IDocumentationRepository documentation)
        {
            _association = association;
            _documentation = documentation;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
                return RedirectToAction("Index", "Login");
            if (HttpContext.Session.GetString("email") == null) return RedirectToAction("Index", "Login");
            DocumentViewModel docviewmodel = new DocumentViewModel
            {
                Associations = _association.GetAllAssociations(),
                Documentation = _documentation.GetAllDocumentations()
            };
            return View(docviewmodel);
        }

        [HttpGet]
        public IActionResult UpdateAssociation(int Id)
        {
            try
            {
                _association.SetAssociationToAccept(Id);
                TempData["successAssociation"] = "Usuário aprovado para avaliação";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }


        }

        [HttpGet]
        public IActionResult DeleteAssociation(int Id)
        {
            try
            {
                if (!_association.ReproveAssociation(Id))
                {
                    TempData["errorAssociation"] = "Erro: Contatar um administrador";
                    return RedirectToAction("Index");

                }

                TempData["warningAssociation"] = "Associação reprovada!";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }


        }
    }
}
