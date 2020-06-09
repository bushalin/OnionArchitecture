using Microsoft.EntityFrameworkCore;
using Onion.API.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.API.Repository
{
    public class OnionAPIDbContext : DbContext
    {
        public OnionAPIDbContext(DbContextOptions<OnionAPIDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
