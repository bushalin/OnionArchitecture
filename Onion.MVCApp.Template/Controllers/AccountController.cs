using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onion.MVCApp.Template.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var client = _httpClientFactory.CreateClient("api");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");

            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var user = client.GetAsync("users/" + _idToken.Subject).GetAwaiter().GetResult();
            if (user.StatusCode == HttpStatusCode.NotFound)
            {
                var userInfo = new UserInfo();
                userInfo.UserId = _idToken.Subject;
                var content = new StringContent(JsonConvert.SerializeObject(userInfo), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PostAsync("users/", content);
            }

            return RedirectToAction("Index", "Location");
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}