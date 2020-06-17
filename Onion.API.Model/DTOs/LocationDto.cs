using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.API.Model.DTOs
{
    public class LocationDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string CurrentLocation { get; set; }
    }
}
