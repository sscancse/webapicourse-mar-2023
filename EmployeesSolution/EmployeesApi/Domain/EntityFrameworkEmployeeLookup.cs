using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Domain;

public class EntityFrameworkEmployeeLookup : IEmployeesLookup
{
    private readonly EmployeesDataContext _context;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _config;

    public EntityFrameworkEmployeeLookup(EmployeesDataContext context, IMapper mapper, MapperConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
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
        return await GetContactInfoAsync<HomeContactItem>(employeeId);
    }

    public async Task<ContactItem?> GetEmployeeContactInfoForWorkAsync(string employeeId)
    {
        return await GetContactInfoAsync<WorkContactItem>(employeeId);
    }

    private async Task<ContactItem?> GetContactInfoAsync<TModel>(string employeeId) where TModel : ContactItem
    {
        return await _context.Employees.Where(emp => emp.Id == int.Parse(employeeId))
                     .ProjectTo<TModel>(_config)
                     .SingleOrDefaultAsync();
    }
}
