using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Onion.MVCApp.Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Onion.MVCApp.Template.Controllers
{
    public class LocationController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<EmployeeLocation> employeeList = new List<EmployeeLocation>();

            var client = _httpClientFactory.CreateClient("api");

            var response = client.GetAsync("https://localhost:44361/api/location");

            var apiResponse = response.Result.Content.ReadAsStringAsync();

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                employeeList = JsonConvert.DeserializeObject<List<EmployeeLocation>>(apiResponse.Result);
            }
            return View(employeeList);
        }

    }
}
