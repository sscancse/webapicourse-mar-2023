﻿using AutoMapper;

namespace EmployeesApi.AutomapperProfiles;

public class Employees : Profile
{
    public Employees()
    {
        CreateMap<EmployeeEntity, EmployeeResponse>()
            .ForMember(dest => dest.EmployeeId, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.NameInformation, opts => opts.MapFrom(src => new NameInformation { FirstName = src.FirstName, LastName = src.LastName }))
            .ForMember(dest => dest.WorkDetails, opts => opts.MapFrom(src => new WorkDetails { Department = src.Department }));
    }
}
