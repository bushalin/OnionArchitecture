using System;
using System.ComponentModel;

namespace Onion.MVCApp.Template.Models
{
    public class LocationEdit
    {
        [DisplayName("Current Location")]
        public string CurrentLocation { get; set; }

        public Guid EmployeeId { get; set; }
    }
}