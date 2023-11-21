using Demo_EF.Data;
using Demo_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _context.Employees.Include(x => x.Department).ToList();
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            //bestaande entity ophalen
            Employee toRemove = _context.Employees.Find(id);

            //entity verwijderen
            _context.Employees.Remove(toRemove);

            //transactie committen in database
            _context.SaveChanges();

            //Index-pagina opnieuw weergegeven (adhv Redirect)
            return RedirectToAction(nameof(Index));
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

        public IActionResult Edit(int id)
        {
            Employee toEdit = _context.Employees.Find(id);

            EmployeeModel model = new EmployeeModel();
            model.FirstName = toEdit.FirstName;
            model.LastName = toEdit.LastName;
            model.BirthDate = toEdit.BirthDate;
            model.DepartmentId = toEdit.DepartmentId;
            model.AllDepartments = _context.Departments
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeeModel model) //id: komt uit URL (niet uit formulier)
        {
            if (ModelState.IsValid)
            {
                //optie 1: nieuwe entity + update
                /*
                Employee employee = new Employee();
                employee.Id = id;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.BirthDate = model.BirthDate;
                employee.DepartmentId = model.DepartmentId;

                _context.Update(employee);
                _context.SaveChanges();
                */

                //optie 2: bestaande entity ophalen (tracked) + wijzigen doorvoeren
                Employee toUpdate = _context.Employees.Find(id);
                toUpdate.FirstName = model.FirstName;
                toUpdate.LastName = model.LastName;
                toUpdate.BirthDate = model.BirthDate;
                toUpdate.DepartmentId = model.DepartmentId;

                _context.SaveChanges(); //wijzigingen zijn reeds getracked

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
