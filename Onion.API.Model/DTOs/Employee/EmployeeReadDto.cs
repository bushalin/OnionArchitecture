using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.API.Model.DTOs.Employee
{
    public class EmployeeReadDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeJobTitle { get; set; }
    }
}
