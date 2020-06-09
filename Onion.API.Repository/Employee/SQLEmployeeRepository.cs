using Onion.API.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.API.Repository.Employee
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly OnionAPIDbContext _context;

        public SQLEmployeeRepository(OnionAPIDbContext context)
        {
            _context = context;
        }

        public void Add(EmployeeModel employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            // The Add method doesn't return the entity directly, but a wrapper entity. Use its .Entity property to get back the value (or return the passed in value):
            _context.Employees.Add(employee);
        }

        public void Delete(int id)
        {

        }

        public void Edit(EmployeeModel employee)
        {
            // we do not need anything here because
            // mapper will be mapping the model and so the entityframework will know the difference
            // see services for the explanation

            // if it is required we can build our own implementation here without automapper
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(p => p.EmployeeId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
