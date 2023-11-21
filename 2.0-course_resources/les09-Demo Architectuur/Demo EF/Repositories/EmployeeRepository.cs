using Demo_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetEmployeesWithDepartment()
        {
            return _context.Employees.Include(x => x.Department).ToList();
        }
    }
}
