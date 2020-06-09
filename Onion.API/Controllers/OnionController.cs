using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.API.Controllers
{
    [Route("api/")]
    public class OnionController : ControllerBase
    {
        [Authorize]
        [Route("message")]
        public string Message()
        {
            return "secret message from api";
        }
    }
}
