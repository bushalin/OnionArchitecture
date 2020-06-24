using Onion.API.Model.Employee;
using System;
using System.Collections.Generic;

namespace Onion.API.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAll();

        EmployeeModel GetById(Guid id);

        void Insert(EmployeeModel model);

        void Update(EmployeeModel model);

        void Delete(Guid id);

        void SaveChanges();
    }
}