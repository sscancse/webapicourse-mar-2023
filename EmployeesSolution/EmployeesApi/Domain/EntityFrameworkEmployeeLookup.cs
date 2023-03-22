using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup : IEmployeesLookup
{
    private readonly EmployeesDataContext _context;
    private readonly IMapper _mapper;

    public EntityFrameworkEmployeeLookup(EmployeesDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId)
    {
        var employee = await _context.Employees
            .Where(e => e.Id == int.Parse(employeeId))
            .SingleOrDefaultAsync();

        if (employee is null)
            return null;

        return _mapper.Map<EmployeeResponse>(employee);
    }

    public async Task<ContactItem?> GetEmployeeContactInfoForHomeAsync(string employeeId)
    {
        return await _context.Employees.Where(emp => emp.Id == int.Parse(employeeId))
             .Select(emp => new ContactItem { Email = emp.HomeEmail, Phone = emp.HomePhone })
             .SingleOrDefaultAsync();
    }

    public async Task<ContactItem?> GetEmployeeContactInfoForWorkAsync(string employeeId)
    {
        return await _context.Employees.Where(emp => emp.Id == int.Parse(employeeId))
             .Select(emp => new ContactItem { Email = emp.WorkEmail, Phone = emp.WorkPhone })
             .SingleOrDefaultAsync();
    }
}
