using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Onion.API.Model.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string EmployeeName { get; set; }
        [Required]
        [MaxLength(250)]
        public string EmployeeAddress { get; set; }
        [Required]
        [MaxLength(200)]
        public string EmployeeJobTitle { get; set; }
    }
}
