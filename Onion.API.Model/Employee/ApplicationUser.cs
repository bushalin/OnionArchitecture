using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Model.Employee
{
    public class ApplicationUser : IdentityUser
    {
        public string UserId { get; set; }
    }
}