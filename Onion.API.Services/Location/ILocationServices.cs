using Microsoft.AspNetCore.JsonPatch;
using Onion.API.Model.DTOs;
using Onion.API.Model.DTOs.Location;
using System;
using System.Collections.Generic;

namespace Onion.API.Services.Location
{
    public interface ILocationServices
    {
        EmployeeLocationDto GetLocationByEmployeeId(Guid employeeId);

        IEnumerable<LocationReadDto> GetAllLocations();

        LocationReadDto GetLocationById(Guid id);

        void LocationEdit(Guid id, LocationUpdateDto obj);

        void PartialLocationUpdate(Guid id, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument);

        IEnumerable<EmployeeLocationDto> GetEmployeeLocations();

        LocationReadDto CreateLocation(LocationCreateDto model);

        void DeleteLocation(Guid id);

        void PartialLocationUpdateByEmployeeId(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument);
    }
}