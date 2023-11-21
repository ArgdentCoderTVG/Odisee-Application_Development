using Demo_EF.Data;

namespace Demo_EF.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesWithDepartment();
    }
}
