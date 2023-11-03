using Microsoft.AspNetCore.Mvc;

namespace Comme_Chez_Swa.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
