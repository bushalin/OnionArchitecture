using Microsoft.AspNetCore.JsonPatch;
using Onion.API.Model.DTOs.Employee;
using System;
using System.Collections.Generic;

namespace Onion.API.Services.Employee
{
    public interface IEmployeeServices
    {
        // service er implementation e DTO use kora hoise.
        // cause in this level there should be logic of how to return the data
        // so in this layer we use the DTO(Data Transfer object
        IEnumerable<EmployeeReadDto> GetAllEmployees();

        EmployeeReadDto GetEmployeeById(Guid id);

        EmployeeReadDto Create(EmployeeCreateDto obj);

        void Edit(Guid id, EmployeeUpdateDto obj);

        void PartialEdit(Guid id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument);

        void Delete(Guid id);
    }
}