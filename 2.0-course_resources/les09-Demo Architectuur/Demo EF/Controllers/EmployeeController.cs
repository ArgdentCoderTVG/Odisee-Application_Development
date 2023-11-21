using Demo_EF.Data;
using Demo_EF.Models;
using Demo_EF.Services;
using Demo_EF.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _context;
        private IEmployeeService _employeeService;

        public EmployeeController(AppDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeViewModel> employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _employeeService.RemoveEmployee(id);

            //Index-pagina opnieuw weergegeven (adhv Redirect)
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            EmployeeFormViewModel model = new EmployeeFormViewModel();
            model.AllDepartments = _employeeService.GetDepartments();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                _employeeService.CreateEmployee(model);
                return RedirectToAction(nameof(Success));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            EmployeeFormViewModel model = _employeeService.GetEmployeeForEdit(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeeFormViewModel model) //id: komt uit URL (niet uit formulier)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
