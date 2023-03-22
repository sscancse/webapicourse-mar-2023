using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Adaptors;

public class EmployeesDataContext : DbContext
{
    public EmployeesDataContext(DbContextOptions<EmployeesDataContext> options) : base(options) { }

    // Create a property of type DbSet<T> for each Entity you want to take control of
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
}
