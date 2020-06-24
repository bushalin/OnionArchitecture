using AutoMapper;
using Onion.API.Model.DTOs;
using Onion.API.Model.DTOs.Location;
using Onion.API.Model.Employee;
using Onion.API.Repository.RepositoryModels;

namespace Onion.API.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationModel, LocationUpdateDto>();
            CreateMap<LocationUpdateDto, LocationModel>();
            CreateMap<LocationReadDto, LocationModel>();
            CreateMap<LocationModel, LocationReadDto>();
            CreateMap<EmployeeLocationRM, EmployeeLocationDto>();
            CreateMap<EmployeeLocationRM, LocationUpdateDto>();
            CreateMap<LocationUpdateDto, EmployeeLocationRM>();
            CreateMap<LocationUpdateDto, LocationReadDto>();
            CreateMap<LocationReadDto, LocationUpdateDto>();
            CreateMap<LocationUpdateDto, EmployeeLocationDto>();
            CreateMap<LocationCreateDto, LocationModel>();
            //CreateMap<Location, LocationUpdateDto>();

            CreateMap<LocationModel, EmployeeLocationUpdateDto>();
            CreateMap<EmployeeLocationUpdateDto, LocationModel>();
        }
    }
}