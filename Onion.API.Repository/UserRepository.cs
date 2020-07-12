using AutoMapper;
using Onion.API.Model;
using Onion.API.Model.DTOs.Users;
using Onion.API.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OnionApiDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(OnionApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserInfoRM GetUserById(string userId)
        {
            var userInfoRM = _context.Users.Where(x => x.UserId == userId).FirstOrDefault();

            var result = new UserInfoRM();
            if (userInfoRM != null)
            {
                result.UserId = userInfoRM.Id;
                result.Username = userInfoRM.UserName;
                result.Email = userInfoRM.Email;
                result.Phone = userInfoRM.PhoneNumber;
            }
            return result;
        }
    }
}