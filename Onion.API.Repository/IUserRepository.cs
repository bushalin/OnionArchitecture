using Onion.API.Model.DTOs.Users;
using Onion.API.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Repository
{
    public interface IUserRepository
    {
        UserInfoRM GetUserById(string userId);
    }
}