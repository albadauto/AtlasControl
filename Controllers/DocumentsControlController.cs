using Microsoft.AspNetCore.Mvc;

namespace AtlasControl.Controllers
{
    public class DocumentsControlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
