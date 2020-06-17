using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Onion.MVCApp.Template.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onion.MVCApp.Template.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(ILogger<EmployeeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Employee> employeeList = new List<Employee>();

            var client = _httpClientFactory.CreateClient("api");

            var response = client.GetAsync("https://localhost:44361/api/Employee");

            var apiResponse = response.Result.Content.ReadAsStringAsync();

            if(apiResponse.IsCompletedSuccessfully)
            {
                employeeList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse.Result);
            }
            return View(employeeList);
        }
    }
}
