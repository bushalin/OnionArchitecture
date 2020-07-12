using Microsoft.AspNetCore.Identity;
using Onion.API.Model.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Services.User
{
    public interface IUserServices
    {
        UserInfoDto GetUserById(string userId);

        IdentityResult CreateUser(UserCreateDto user);
    }
}