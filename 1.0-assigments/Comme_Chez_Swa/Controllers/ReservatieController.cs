using Comme_Chez_Swa.Models.Reservatie;
using Microsoft.AspNetCore.Mvc;

namespace Comme_Chez_Swa.Controllers
{
    public class ReservatieController : Controller
    {
        public IActionResult Reserveer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserveer(UserBindingModel userModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
