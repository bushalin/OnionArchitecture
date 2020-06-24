using System;

namespace Onion.MVCApp.Template.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
    }
}