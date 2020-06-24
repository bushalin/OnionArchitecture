using Onion.API.Model.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.API.Model.Employee
{
    public class LocationModel : AuditableEnitity
    {
        public string CurrentLocation { get; set; }

        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeModel EmployeeModel { get; set; }
    }
}