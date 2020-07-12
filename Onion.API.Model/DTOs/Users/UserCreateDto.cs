using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Model.DTOs.Users
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
    }
}