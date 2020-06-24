using Onion.API.Model.Employee;
using Onion.API.Repository.RepositoryModels;
using System;
using System.Collections.Generic;

namespace Onion.API.Repository
{
    public interface ILocationRepository
    {
        LocationModel GetById(Guid id);

        IEnumerable<LocationModel> GetAll();

        void Insert(LocationModel model);

        void Update(LocationModel model);

        void Delete(Guid id);

        void SaveChanges();

        EmployeeLocationRM GetByEmployeeId(Guid id);

        IEnumerable<EmployeeLocationRM> GetEmployeeLocations();

        LocationModel GetLocationByEmployeeId(Guid employeeId);

        //void UpdateEmployeeLocation(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument);

        void UpdateLocationState(LocationModel model);
    }
}