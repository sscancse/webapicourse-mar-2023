namespace EmployeesApi.Domain;

public interface IEmployeesLookup
{
    Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId);
}