using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.MVCApp.Models.ViewModels.Employee;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onion.MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            var client = _httpClientFactory.CreateClient();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            client.SetBearerToken(accessToken);
            var content = client.GetAsync("https://localhost:44361/api/employee");

            employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(content.Result.Content.ReadAsStringAsync().Result);
            return View(employeeList);
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
    }
}