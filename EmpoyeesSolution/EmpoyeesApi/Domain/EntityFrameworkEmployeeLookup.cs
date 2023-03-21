namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup : IEmployeesLookup
{
    private readonly EmployeesDataContext _context;

    public EntityFrameworkEmployeeLookup(EmployeesDataContext context)
    {
        _context = context;
    }

    public Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId)
    {
        throw new NotImplementedException();
    }
}
