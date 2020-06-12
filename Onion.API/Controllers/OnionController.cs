using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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