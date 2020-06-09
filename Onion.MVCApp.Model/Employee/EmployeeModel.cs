using System.ComponentModel.DataAnnotations;

namespace Onion.MVCApp.Model
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeJobTitle { get; set; }
    }
}
