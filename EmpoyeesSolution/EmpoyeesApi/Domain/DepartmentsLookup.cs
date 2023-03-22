using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public class DepartmentsLookup : IDepartmentsLookup
{
    private readonly EmployeesDataContext _context;
    private readonly MapperConfiguration _config;

    public DepartmentsLookup(EmployeesDataContext context, MapperConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<List<DepartmentItem>> GetDepartmentsAsync()
    {
        // Never use .Result - always use async method and await
        return await _context.Departments
            .OrderBy(dept => dept.Code)
            .ProjectTo<DepartmentItem>(_config)
            .ToListAsync();
    }
}
