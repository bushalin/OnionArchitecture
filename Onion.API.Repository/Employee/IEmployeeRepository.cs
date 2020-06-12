using Onion.API.Model.Employee;
using System.Collections.Generic;

namespace Onion.API.Repository.Employee
{
    public interface IEmployeeRepository
    {
        void SaveChanges();

        // in this level the return type is basic employee type.
        // because this layer's only job is to return the data.
        // this should be independent to the business layer logic or return type.
        IEnumerable<EmployeeModel> GetAllEmployee();

        EmployeeModel GetEmployeeById(int id);

        void Add(EmployeeModel employee);

        void Edit(EmployeeModel employee);

        void Delete(int id);
    }
}