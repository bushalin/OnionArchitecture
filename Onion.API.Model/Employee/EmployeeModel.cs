using Onion.API.Model.Common;

namespace Onion.API.Model.Employee
{
    public class EmployeeModel : AuditableEnitity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
    }
}