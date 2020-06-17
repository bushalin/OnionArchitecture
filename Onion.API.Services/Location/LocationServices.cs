using Onion.API.Model;
using Onion.API.Model.DTOs;
using Onion.API.Repository.Location;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Services.Location
{
    public class LocationServices : ILocationServices
    {
        private readonly ILocationRepository _repository;
        private readonly OnionApiDbContext _context;

        public LocationServices(ILocationRepository locationRepository, OnionApiDbContext context)
        {
            _repository = locationRepository;
            _context = context;
        }
        public IEnumerable<LocationDto> GetEmployeeLocations()
        {
            var result = _context.Employees.Select(x => new LocationDto
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.EmployeeName,
                JobTitle = x.EmployeeJobTitle,
                CurrentLocation = _context.Locations.Where(v => v.EmployeeId == x.EmployeeId).Select(y => y.EmployeeLocation).FirstOrDefault()
            }).ToList();
            return result;
        }

    }
}
