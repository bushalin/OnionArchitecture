using System;

namespace Onion.API.Model.DTOs
{
    public class LocationReadDto
    {
        public Guid Id { get; set; }
        public string CurrentLocation { get; set; }
        public Guid EmployeeId { get; set; }
    }
}