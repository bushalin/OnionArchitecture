using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Onion.API.Model.DTOs;
using Onion.API.Model.DTOs.Location;
using Onion.API.Services.Location;
using System;

namespace Onion.API.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationServices _services;

        public LocationController(ILocationServices locationServices)
        {
            _services = locationServices;
        }

        #region BASIC_CRUD

        // GET /api/Location
        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var result = _services.GetAllLocations();
            return Ok(result);
        }

        // GET /api/location/{id}
        [HttpGet("{id}", Name = "GetLocationById")]
        public IActionResult GetLocationById(Guid id)
        {
            var result = _services.GetLocationById(id);
            return Ok(result);
        }

        // POST /api/location
        [HttpPost]
        public IActionResult CreateLocation([FromBody]LocationCreateDto model)
        {
            var result = _services.CreateLocation(model);
            return CreatedAtRoute(nameof(GetLocationById), new { Id = result.Id }, result);
        }

        // PUT /api/location
        [HttpPut("{id}")]
        public IActionResult EditLocation(Guid id, LocationUpdateDto model)
        {
            var result = _services.GetLocationById(id);
            if (result == null)
            {
                return NotFound();
            }
            _services.LocationEdit(id, model);
            return NoContent();
        }

        // PATCH /api/location/{id}
        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(Guid id, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        {
            var result = _services.GetLocationById(id);
            if (result == null)
            {
                return NotFound();
            }
            _services.PartialLocationUpdate(id, jsonPatchDocument);

            return NoContent();
        }

        // DELETE /api/location/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(Guid id)
        {
            var result = _services.GetLocationById(id);
            if (result == null)
            {
                return NotFound();
            }

            _services.DeleteLocation(id);

            return NoContent();
        }

        #endregion BASIC_CRUD

        #region EMPLOYEE_SPECIFIC_LOCATION

        // GET /api/location/GetByEmployeeId/{id}
        [HttpGet]
        [Route("GetLocationByEmployeeId/{id}")]
        public IActionResult GetLocationByEmployeeId(Guid id)
        {
            var result = _services.GetLocationByEmployeeId(id);

            return Ok(result);
        }

        // GET /api/location/GetAllEmployeeLocations
        [HttpGet]
        [Route("GetAllEmployeeLocations")]
        public IActionResult GetAllEmployeeLocations()
        {
            var result = _services.GetEmployeeLocations();

            return Ok(result);
        }

        // PATCH /api/location/UpdateEmployeeLocation/{id}
        [HttpPatch]
        [Route("UpdateEmployeeLocation/{employeeId}")]
        public IActionResult CreateEmployeeLocation(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        {
            //var result = _services.GetLocationByEmployeeId(employeeId);
            //if (result == null)
            //{
            //    return NotFound();
            //}

            _services.PartialLocationUpdateByEmployeeId(employeeId, jsonPatchDocument);
            return NoContent();
        }

        #endregion EMPLOYEE_SPECIFIC_LOCATION
    }
}