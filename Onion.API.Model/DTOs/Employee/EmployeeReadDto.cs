using System;

namespace Onion.API.Model.DTOs.Employee
{
    public class EmployeeReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
    }
}