namespace EmployeesApi.Domain;

public class FakeDepartmentsLookup : IDepartmentsLookup
{
    public async Task<List<DepartmentItem>> GetDepartmentsAsync()
    {
        return new List<DepartmentItem>() { new DepartmentItem { Id = "CEO", Description = "Running Things" } };
    }
}
