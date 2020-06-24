using System;

namespace Onion.API.Model.DTOs.Location
{
    public class EmployeeLocationUpdateDto
    {
        public Guid Id { get; set; }
        public string CurrentLocation { get; set; }
        public Guid EmployeeId { get; set; }
    }
}