using System.ComponentModel.DataAnnotations;

namespace Onion.API.Model.DTOs.Employee
{
    public class EmployeeUpdateDto
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