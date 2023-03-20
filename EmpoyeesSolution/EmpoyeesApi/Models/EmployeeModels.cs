namespace EmployeesApi.Models;

public record EmployeeSummaryResponse(int Total, int FullTime, int PartTime, string DepatmentFilter);

public record EmployeeResponse(string Id, string FirsName, string LastName, string Department);