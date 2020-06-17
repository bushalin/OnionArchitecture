using Microsoft.AspNetCore.Mvc;
using Onion.API.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Services.Location
{
    public interface ILocationServices
    {
        IEnumerable<LocationDto> GetEmployeeLocations();
    }
}
