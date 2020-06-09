using Microsoft.AspNetCore.JsonPatch;
using Onion.API.Model.DTOs.Employee;
using Onion.API.Model.Employee;
using System.Collections.Generic;

namespace Onion.API.Services.Employee
{
    public interface IEmployeeServices
    {
        // service er implementation e DTO use kora hoise.
        // cause in this level there should be logic of how to return the data
        // so in this layer we use the DTO(Data Transfer object
        IEnumerable<EmployeeReadDto> GetAllEmployees();
        EmployeeReadDto GetEmployeeById(int id);

        EmployeeModel Create(EmployeeCreateDto obj);

        void Edit(int id, EmployeeUpdateDto obj);

        void PartialEdit(int id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument);

        void Delete(int id);
    }
}
