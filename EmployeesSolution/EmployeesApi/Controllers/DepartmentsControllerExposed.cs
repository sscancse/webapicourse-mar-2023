using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers;

public class DepartmentsControllerExposed : ControllerBase
{
    private readonly EmployeesDataContext _context;

    public DepartmentsControllerExposed(EmployeesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/departments/exposed")]
    public async Task<ActionResult> GetDepartments()
    {
        // Anti-Pattern - returning entity objects (Domain objects)
        var response = await _context.Departments.OrderBy(d => d.Code).ToListAsync();
        return Ok(response);
    }
}
