using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "IT" },
                new Department() { Id = 2, Name = "HR" },
                new Department() { Id = 3, Name = "Finance" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(2001, 5, 25), DepartmentId = 1 }
            );
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
