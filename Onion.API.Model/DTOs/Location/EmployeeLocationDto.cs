using System;

namespace Onion.API.Model.DTOs.Location
{
    public class EmployeeLocationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string CurrentLocation { get; set; }
    }
}