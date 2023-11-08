using Comme_Chez_Swa.Models.Reservatie;
using Microsoft.AspNetCore.Mvc;

namespace Comme_Chez_Swa.Controllers
{
    public class ReservatieController : Controller
    {
        public IActionResult Reserveer()
        {
            ReservatieBindingModel bindingModel = new ReservatieBindingModel();
            return View(bindingModel);
        }

        [HttpPost]
        public IActionResult Reserveer(ReservatieBindingModel userModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View(userModel);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
