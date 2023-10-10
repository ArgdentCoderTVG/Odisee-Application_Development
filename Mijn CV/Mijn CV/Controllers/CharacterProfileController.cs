using Microsoft.AspNetCore.Mvc;

namespace Mijn_CV.Controllers
{
    public class CharacterProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
