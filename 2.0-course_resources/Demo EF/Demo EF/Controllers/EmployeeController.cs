using Demo_EF.Data;
using Demo_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_EF.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            EmployeeModel model = new EmployeeModel();
            model.AllDepartments = _context.Departments
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                //sla employee op in DB
                Employee employee = new Employee();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.BirthDate = model.BirthDate;
                employee.DepartmentId = model.DepartmentId;

                _context.Add(employee);
                _context.SaveChanges();

                return RedirectToAction(nameof(Success));
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
