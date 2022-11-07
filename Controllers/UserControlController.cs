using Microsoft.AspNetCore.Mvc;

namespace AtlasControl.Controllers
{
    public class UserControlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
