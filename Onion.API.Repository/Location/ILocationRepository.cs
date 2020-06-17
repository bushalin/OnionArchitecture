using Onion.API.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Onion.API.Repository.Location
{
    public interface ILocationRepository
    {
        IEnumerable<Model.Employee.Location> GetLocations();

        JsonResult GetEmployeeLocations();

        Model.Employee.Location GetLocationById(int id);

        void Add(Model.Employee.Location location);

        void Edit();

        void Delete(int id);

        void SaveChanges();
    }
}
