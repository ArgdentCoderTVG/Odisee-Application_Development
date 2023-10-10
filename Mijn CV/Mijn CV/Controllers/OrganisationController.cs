using Microsoft.AspNetCore.Mvc;

namespace Mijn_CV.Controllers
{
    public class OrganisationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
