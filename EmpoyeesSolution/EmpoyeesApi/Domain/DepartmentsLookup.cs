using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public class DepartmentsLookup : IDepartmentsLookup
{
    private readonly EmployeesDataContext _context;

    public DepartmentsLookup(EmployeesDataContext context)
    {
        _context = context;
    }

    public async Task<List<DepartmentItem>> GetDepartmentsAsync()
    {
        return await _context.Departments.
            Select(dept => new DepartmentItem(dept.Code, dept.Description)).
            ToListAsync();
    }
}
