using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.MVCApp.Models.ViewModels.Employee;
using System.Collections.Generic;
using System.Net.Http;

namespace Onion.MVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }
        [Authorize]
        public IActionResult Index()
        {
            // adding the list to the controller. for calling the api we are using the HttpClient class
            // see the implementation for more description
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();

            var client = _httpClient.CreateClient("api");

            var response = client.GetAsync("https://localhost:44361/api/Employee");

            var apiResponse = response.Result.Content.ReadAsStringAsync();

            if(apiResponse.IsCompletedSuccessfully)
            {
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(apiResponse.Result);
            }

            return View(employeeList);
        }
    }
}