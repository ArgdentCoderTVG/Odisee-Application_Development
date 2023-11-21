using Demo_EF.Data;
using Demo_EF.Repositories;
using Demo_EF.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_EF.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepo;
        private IRepository<Department> _departmentRepo;

        public EmployeeService(IEmployeeRepository employeeRepo,
            IRepository<Department> departmentRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
        }

        public int CreateEmployee(EmployeeFormViewModel model)
        {
            Employee employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                DepartmentId = model.DepartmentId
            };

            _employeeRepo.Add(employee);
            _employeeRepo.SaveChanges();

            return employee.Id;
        }

        public EmployeeFormViewModel GetEmployeeForEdit(int id)
        {
            Employee toEdit = _employeeRepo.GetById(id);
            EmployeeFormViewModel model = new EmployeeFormViewModel()
            {
                FirstName = toEdit.FirstName,
                LastName = toEdit.LastName,
                BirthDate = toEdit.BirthDate,
                DepartmentId = toEdit.DepartmentId,
                AllDepartments = GetDepartments()
            };

            return model;
        }

        public IEnumerable<SelectListItem> GetDepartments()
        {
            return _departmentRepo.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

        public void RemoveEmployee(int id)
        {
            Employee toRemove = _employeeRepo.GetById(id);
            _employeeRepo.Delete(toRemove);
            _employeeRepo.SaveChanges();
        }

        public void UpdateEmployee(int id, EmployeeFormViewModel model)
        {
            Employee toUpdate = _employeeRepo.GetById(id);
            toUpdate.FirstName = model.FirstName;
            toUpdate.LastName = model.LastName;
            toUpdate.BirthDate = model.BirthDate;
            toUpdate.DepartmentId = model.DepartmentId;

            _employeeRepo.Update(toUpdate);
            _employeeRepo.SaveChanges();
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            return _employeeRepo.GetEmployeesWithDepartment().Select(x => new EmployeeViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                DepartmentName = x.Department.Name
            });
        }
    }
}
