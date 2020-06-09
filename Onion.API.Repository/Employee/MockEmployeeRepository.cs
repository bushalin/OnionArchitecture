using Onion.API.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.API.Repository.Employee
{
    public class MockEmployeeRepo : IEmployeeRepository
    {
        public void Add(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            var employees = new List<EmployeeModel>
            {
                new EmployeeModel{EmployeeId = 1, EmployeeName = "Hasib", EmployeeAddress = "Bangladesh", EmployeeJobTitle = "Software Engineer"},
                new EmployeeModel{EmployeeId = 2, EmployeeName = "Imran", EmployeeAddress = "Bangladesh", EmployeeJobTitle = "Software Engineer"},
                new EmployeeModel{EmployeeId = 3, EmployeeName = "Ichinose", EmployeeAddress = "Japan", EmployeeJobTitle = "Civil Engineer"},
                new EmployeeModel{EmployeeId = 4, EmployeeName = "Hayato", EmployeeAddress = "Japan", EmployeeJobTitle = "Civil Engineer"},
            };

            return employees;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            return new EmployeeModel
            {
                EmployeeId = 1,
                EmployeeName = "Hasib",
                EmployeeAddress = "Bangladesh",
                EmployeeJobTitle = "Software Engineer"
            };
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
