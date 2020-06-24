using System;

namespace Onion.API.Model.DTOs
{
    public class LocationUpdateDto
    {
        public string CurrentLocation { get; set; }
        public Guid EmployeeId { get; set; }
    }
}