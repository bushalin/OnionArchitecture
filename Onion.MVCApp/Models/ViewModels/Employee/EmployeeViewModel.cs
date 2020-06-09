using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.MVCApp.Models.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeJobTitle { get; set; }
    }
}
