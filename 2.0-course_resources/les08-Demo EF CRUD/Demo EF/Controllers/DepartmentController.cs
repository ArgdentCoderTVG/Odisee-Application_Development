using Demo_EF.Data;
using Demo_EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_EF.Controllers
{
    public class DepartmentController : Controller
    {
        private AppDbContext _context;
        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentModel model)
        {
            if(ModelState.IsValid)
            {
                Department department = new Department();
                department.Name = model.Name;

                _context.Add(department);
                _context.SaveChanges();
                //department bewaren

                return RedirectToAction(nameof(Success)); //POST/REDIRECT/GET-pattern
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
