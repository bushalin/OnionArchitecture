using System;

namespace Onion.API.Model.DTOs.Location
{
    public class LocationCreateDto
    {
        public string CurrentLocation { get; set; }
        public Guid EmployeeId { get; set; }
    }
}