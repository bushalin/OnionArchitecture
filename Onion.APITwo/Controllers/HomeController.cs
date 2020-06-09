using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onion.APITwo.Controllers
{
    public class HomeController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            // retrieve access token from server
            var serverClient = _httpClientFactory.CreateClient();

            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44367/");

            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "api_two_id",
                ClientSecret = "api_two_secret",

                Scope = "basicIdentityApi"
            });

            // retrieve secret data

            var apiClient = _httpClientFactory.CreateClient();

            var response = await apiClient.GetAsync("https://localhost:44361/api/message");

            var content = await response.Content.ReadAsStringAsync();


            return Ok(new
            {
                access_token = tokenResponse.AccessToken,
                message = content
            });
        }
    }
}
