using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup : IEmployeesLookup
{
    private readonly EmployeesDataContext _context;

    public EntityFrameworkEmployeeLookup(EmployeesDataContext context)
    {
        _context = context;
    }

    public async Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId)
    {
        var employee = await _context.Employees
            .Where(e => e.Id == int.Parse(employeeId))
            .SingleOrDefaultAsync();

        if (employee is null)
            return null;

        return new EmployeeResponse(employee.Id.ToString(), new NameInformation(employee.FirstName, employee.LastName), new WorkDetails(employee.Department),
            new Dictionary<string, Dictionary<string, string>>
            {
                {"home", new Dictionary<string, string>{ { "email", employee.HomeEmail }, {"phone", employee.HomePhone } } },
                {"work", new Dictionary<string, string>{ {"email", employee.WorkEmail},{"phone", employee.WorkPhone } } },
            }
        );
    }
}
