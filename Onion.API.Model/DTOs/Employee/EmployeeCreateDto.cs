using System.ComponentModel.DataAnnotations;

namespace Onion.API.Model.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string JobTitle { get; set; }
    }
}