using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Onion.API.Model.DTOs.Employee;
using Onion.API.Model.Employee;
using Onion.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Services.Employee
{
    public class EmployeeDTOServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeDTOServices(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public EmployeeReadDto Create(EmployeeCreateDto obj)
        {
            var employeeModel = _mapper.Map<EmployeeModel>(obj);

            _repository.Insert(employeeModel);
            _repository.SaveChanges();

            return _mapper.Map<EmployeeReadDto>(employeeModel);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void Edit(Guid id, EmployeeUpdateDto obj)
        {
            var employeeModelFromRepository = _repository.GetById(id);
            var employeeModel = _mapper.Map(obj, employeeModelFromRepository);

            _repository.Update(employeeModel);
            // we are saving this changes in the database by this line
            _repository.SaveChanges();
        }

        public IEnumerable<EmployeeReadDto> GetAllEmployees()
        {
            var result = _repository.GetAll().ToList();
            return _mapper.Map<IEnumerable<EmployeeReadDto>>(result);
        }

        public EmployeeReadDto GetEmployeeById(Guid id)
        {
            var result = _repository.GetById(id);
            return _mapper.Map<EmployeeReadDto>(result);
        }

        public void PartialEdit(Guid id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument)
        {
            var employeeModelFromRepository = _repository.GetById(id);
            var employeeModel = _mapper.Map<EmployeeUpdateDto>(employeeModelFromRepository);

            jsonPatchDocument.ApplyTo(employeeModel);

            var result = _mapper.Map(employeeModel, employeeModelFromRepository);

            _repository.Update(result);

            _repository.SaveChanges();
        }
    }
}