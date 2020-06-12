using AutoMapper;
using Onion.API.Model.DTOs.Employee;
using Onion.API.Model.Employee;

namespace Onion.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // source -> target
            CreateMap<EmployeeModel, EmployeeReadDto>();
            CreateMap<EmployeeModel, EmployeeCreateDto>();
            CreateMap<EmployeeCreateDto, EmployeeModel>();
            CreateMap<EmployeeUpdateDto, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeUpdateDto>();
        }
    }
}