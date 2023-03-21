namespace EmployeesApi.Domain
{
    public interface IDepartmentsLookup
    {
        Task<List<DepartmentItem>> GetDepartmentsAsync();
    }
}