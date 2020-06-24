using Onion.API.Model;
using Onion.API.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OnionApiDbContext _context;

        public EmployeeRepository(OnionApiDbContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var result = _context.Employees.Find(id);
            _context.Remove(result);
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            return _context.Employees.AsEnumerable();
        }

        public EmployeeModel GetById(Guid id)
        {
            return _context.Employees.Find(id);
        }

        public void Insert(EmployeeModel model)
        {
            _context.Add(model);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(EmployeeModel model)
        {
        }
    }
}