using Microsoft.AspNetCore.Identity;
using Onion.API.Model.DTOs.Users;
using Onion.API.Model.Employee;
using Onion.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public UserInfoDto GetUserById(string userId)
        {
            var resultRM = _userRepository.GetUserById(userId);
            var result = new UserInfoDto
            {
                UserId = resultRM.UserId,
                Username = resultRM.Username,
                Email = resultRM.Email,
                Phone = resultRM.Phone
            };
            return result;
        }

        public IdentityResult CreateUser(UserCreateDto user)
        {
            var userModel = new ApplicationUser
            {
                UserId = user.UserId,
                UserName = user.Username
            };
            var result = _userManager.CreateAsync(userModel);
            return result.GetAwaiter().GetResult();
        }
    }
}