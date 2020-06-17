using Microsoft.AspNetCore.Mvc;
using Onion.API.Services.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController: Controller
    {
        private readonly ILocationServices _services;

        public LocationController(ILocationServices locationServices)
        {
            _services = locationServices;
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var result = _services.GetEmployeeLocations();
            return Ok(result);
        }
    }
}
