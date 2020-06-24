using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onion.API.Model.Employee;

namespace Onion.API.Model
{
    public class OnionApiDbContext : IdentityDbContext
    {
        public OnionApiDbContext(DbContextOptions<OnionApiDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
    }
}