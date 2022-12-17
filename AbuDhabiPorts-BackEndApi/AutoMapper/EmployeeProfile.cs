using AbuDhabiPorts_BackEndApi.Models;
using AbuDhabiPorts_BackEndApi.ViewModels.Employees;
using AutoMapper;

namespace AbuDhabiPorts_BackEndApi.AutoMapper;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeViewModel, Employee>()
            .ForMember(dest => dest.FullName, options => options.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => src.Address))
            .ForMember(dest => dest.Salary, options => options.MapFrom(src => src.Salary))
            .ForMember(dest => dest.DateOfBirth, options => options.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => src.Address))
            .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<Employee, EmployeeViewModel>()
            .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, options => options.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => src.Address))
            .ForMember(dest => dest.Salary, options => options.MapFrom(src => src.Salary))
            .ForMember(dest => dest.DateOfBirth, options => options.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Address, options => options.MapFrom(src => src.Address))
            .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
            .ReverseMap();
    }
}
