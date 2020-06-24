using System;

namespace Onion.MVCApp.Template.Models
{
    public class EmployeeLocation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string CurrentLocation { get; set; }
    }
}