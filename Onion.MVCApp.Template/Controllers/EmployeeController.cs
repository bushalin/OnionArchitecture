using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.MVCApp.Template.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onion.MVCApp.Template.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();

            var client = _httpClient.CreateClient("api");

            var serverClient = _httpClient.CreateClient();
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44367/");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
            // var _refreshToken = new JwtSecurityTokenHandler().ReadJwtToken(refreshToken);

            var userInfoRequest = new UserInfoRequest
            {
                Address = discoveryDocument.UserInfoEndpoint,
                Token = accessToken
            };

            var userInfoResponse = serverClient.GetUserInfoAsync(userInfoRequest).GetAwaiter().GetResult();

            var userFinder = client.GetAsync("Employee/" + _idToken.Subject);
            client.SetBearerToken(accessToken);
            var response = client.GetAsync("Employee");

            var apiResponse = response.Result.Content.ReadAsStringAsync();

            if (apiResponse.IsCompletedSuccessfully)
            {
                employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse.Result);
            }

            return View(employees);
        }
    }
}