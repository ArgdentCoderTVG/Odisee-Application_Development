using Demo_EF.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_EF.Services
{
    public interface IEmployeeService
    {
        int CreateEmployee(EmployeeFormViewModel model);
        void UpdateEmployee(int id, EmployeeFormViewModel model);
        EmployeeFormViewModel GetEmployeeForEdit(int id);
        void RemoveEmployee(int id);
        IEnumerable<SelectListItem> GetDepartments();

        IEnumerable<EmployeeViewModel> GetAllEmployees();
    }
}
