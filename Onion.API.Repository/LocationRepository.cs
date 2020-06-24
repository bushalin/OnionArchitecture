using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Onion.API.Model;
using Onion.API.Model.Employee;
using Onion.API.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly OnionApiDbContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(OnionApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            var result = _context.Locations.Find(id);
            _context.Remove(result);
        }

        public IEnumerable<LocationModel> GetAll()
        {
            var result = _context.Locations.AsEnumerable();
            return result;
        }

        public IEnumerable<EmployeeLocationRM> GetEmployeeLocations()
        {
            var result = _context.Employees.Select(x => new EmployeeLocationRM
            {
                Id = x.Id,
                Name = x.Name,
                JobTitle = x.JobTitle,
                CurrentLocation = _context.Locations.Where(v => v.EmployeeId == x.Id).Select(y => y.CurrentLocation).FirstOrDefault()
            }).ToList();

            return result;
        }

        public EmployeeLocationRM GetByEmployeeId(Guid id)
        {
            //var result = _context.Locations.Where(x => x.EmployeeId == id).FirstOrDefault();
            var result = _context.Locations.Where(x => x.EmployeeId == id)
                .Select(x => new EmployeeLocationRM
                {
                    Id = x.Id,
                    Name = x.EmployeeModel.Name,
                    JobTitle = x.EmployeeModel.JobTitle,
                    CurrentLocation = x.CurrentLocation
                }).FirstOrDefault();
            return result;
        }

        public LocationModel GetById(Guid id)
        {
            var result = _context.Locations.Find(id);
            return result;
        }

        public void Insert(LocationModel model)
        {
            _context.Add(model);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(LocationModel model)
        {
            //DON'T HAVE TO DO ANYTHING, CAUSE AUTOMAPPER DOES THE TRACKING OF THE CONTEXT IN THE SERVICE LAYER
        }

        public LocationModel GetLocationByEmployeeId(Guid employeeId)
        {
            var result = _context.Locations.Where(x => x.EmployeeId == employeeId).Select(x => new LocationModel
            {
                Id = x.Id,
                CurrentLocation = x.CurrentLocation,
                EmployeeId = x.EmployeeId
            }).FirstOrDefault();

            return result;
        }

        //public void UpdateEmployeeLocation(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        //{
        //    var model = _context.Locations.Where(x => x.EmployeeId == employeeId).Select(x => new LocationModel
        //    {
        //        CurrentLocation = x.CurrentLocation,
        //        EmployeeId = x.EmployeeId,
        //        Id = x.Id
        //    }).FirstOrDefault();

        //    var locationModel = _mapper.Map<LocationUpdateDto>(model);

        //    jsonPatchDocument.ApplyTo(locationModel);

        //    var result = _mapper.Map(locationModel, model);

        //    _context.Entry(result).State = EntityState.Modified;

        //    _context.SaveChanges();
        //}

        public void UpdateLocationState(LocationModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}