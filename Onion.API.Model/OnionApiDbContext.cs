using Microsoft.EntityFrameworkCore;
using Onion.API.Model.Employee;

namespace Onion.API.Model
{
    public class OnionApiDbContext : DbContext
    {
        public OnionApiDbContext(DbContextOptions<OnionApiDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}