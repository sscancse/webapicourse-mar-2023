namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{
    private readonly IEmployeesLookup _employeeLookupService;

    public EmployeesController(IEmployeesLookup employeeLookupService)
    {
        _employeeLookupService = employeeLookupService;
    }

    // GET /employees
    [HttpGet("/employees")]
    public async Task<ActionResult<EmployeeSummaryResponse>> GetAllEmployees([FromQuery] string dept = "All")
    {
        var response = new EmployeeSummaryResponse(18, 10, 8, dept);
        return Ok(response); // Serializes .NET object to client
    }

    [HttpGet("/employees/{employeeId}")]
    public async Task<ActionResult<EmployeeResponse>> GetEmployeeById([FromRoute] string employeeId)
    {
        EmployeeResponse? response = await _employeeLookupService.GetEmployeeByIdAsync(employeeId);

        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
        // 200 Ok with that employee
        // 404
    }
}
