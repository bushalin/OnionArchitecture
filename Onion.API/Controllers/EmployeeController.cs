using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Onion.API.Model.DTOs.Employee;
using Onion.API.Services.Employee;
using System;
using System.Net;

namespace Onion.API.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController: Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeServices employeeServices, IMapper mapper)
        {
            _employeeServices = employeeServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeServices.GetAllEmployees());
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var result = _employeeServices.GetEmployeeById(id);
            if(result != null)
            {
                return Ok(result);
            }

            return NotFound();
            // output of NotFound() => JSON OUTPUT
            //{
            //    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            //    "title": "Not Found",
            //    "status": 404,
            //    "traceId": "|ff9aadd1-4898ea936fc947c4."
            //}
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeCreateDto obj)
        {
            var result = _mapper.Map<EmployeeReadDto>(_employeeServices.Create(obj));

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = result.EmployeeId }, result);
        }

        // this is not a good way to implement edit
        // HttpPut requires the whole object to edit, so it is hard to maintain and ERROR-PRONE
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeUpdateDto obj)
        {
            var employeeModelFromRepo = _employeeServices.GetEmployeeById(id);
            if(employeeModelFromRepo == null)
            {
                return NotFound();
            }
            try
            {
                _employeeServices.Edit(id, obj);
                return NoContent();
            }
            catch(Exception e)
            {
                const string msg = "Unable to PUT update employee request";
                return StatusCode((int)HttpStatusCode.InternalServerError, msg);
            }
        }

        // PATCH api/employee/{id}
        [HttpPatch("{id}")]
        public IActionResult PartialEmployeeUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument)
        {
            var employeeModelFromRepo = _employeeServices.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            _employeeServices.PartialEdit(id, jsonPatchDocument);

            return NoContent();
        }
    }
}
