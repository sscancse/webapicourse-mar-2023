namespace EmployeesApi.Domain;

public interface IEmployeesLookup
{
    Task<EmployeeResponse?> GetEmployeeByIdAsync(string employeeId);
    Task<ContactItem?> GetEmployeeContactInfoForHomeAsync(string employeeId);
    Task<ContactItem?> GetEmployeeContactInfoForWorkAsync(string employeeId);
}