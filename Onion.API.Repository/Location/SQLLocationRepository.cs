using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Onion.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Repository.Location
{
    public class SQLLocationRepository : ILocationRepository
    {
        private readonly OnionApiDbContext _context;

        public SQLLocationRepository(OnionApiDbContext context)
        {
            _context = context;
        }

        public void Add(Model.Employee.Location location)
        {
            if(location == null)
            {
                throw new ArgumentNullException();
            }

            _context.Locations.Add(location);
        }

        public void Delete(int id)
        {
            var result = GetLocationById(id);
            _context.Remove(result);
        }

        public void Edit()
        {
            // throw new NotImplementedException();
        }

        public JsonResult GetEmployeeLocations()
        {
            var result = _context.Employees.Join(_context.Locations,
                u => u.EmployeeId,
                v => v.EmployeeId,
                (u, v) => new { Employee = u, Location = v })
                .Select(x => new
                {
                    x.Employee.EmployeeName,
                    //x.Location.EmployeeLocation
                });
            return new JsonResult ( new 
            {
                Data = result
            });
        }

        public Model.Employee.Location GetLocationById(int id)
        {
            return _context.Locations.Find(id);
        }

        public IEnumerable<Model.Employee.Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
