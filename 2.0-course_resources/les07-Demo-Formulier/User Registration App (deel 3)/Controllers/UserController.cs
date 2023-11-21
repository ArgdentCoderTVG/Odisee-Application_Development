using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User_Registration_App.Models;

namespace User_Registration_App.Controllers
{
    public class UserController : Controller
    {
        //GET-request (opvragen formulier)
        public IActionResult Create()
        {
            UserBindingModel model = new UserBindingModel();
            return View(model);
        }

        //POST-request (ontvangen en verwerken van gegevens)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserBindingModel userModel)
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
