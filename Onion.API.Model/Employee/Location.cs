using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.API.Model.Employee
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string EmployeeLocation { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual EmployeeModel EmployeeModel { get; set; }
    }
}