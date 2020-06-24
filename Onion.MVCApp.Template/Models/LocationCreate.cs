using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onion.MVCApp.Template.Models
{
    public class LocationCreate
    {
        [Required]
        [DisplayName("Current Location")]
        public string CurrentLocation { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
    }
}