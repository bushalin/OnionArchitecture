using Microsoft.AspNetCore.Mvc;
using Onion.API.Model.DTOs.Users;
using Onion.API.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public IActionResult GetUserById(string userId)
        {
            var result = _userService.GetUserById(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserCreateDto createDto)
        {
            var result = _userService.CreateUser(createDto);
            return Ok(result);
        }
    }
}