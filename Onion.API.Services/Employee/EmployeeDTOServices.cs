using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Onion.API.Model.DTOs.Employee;
using Onion.API.Model.Employee;
using Onion.API.Repository.Employee;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Services.Employee
{
    public class EmployeeDTOServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeDTOServices(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public EmployeeReadDto Create(EmployeeCreateDto obj)
        {
            var employeeModel = _mapper.Map<EmployeeModel>(obj);

            _employeeRepo.Add(employeeModel);
            _employeeRepo.SaveChanges();

            return _mapper.Map<EmployeeReadDto>(employeeModel);
        }

        public void Delete(int id)
        {
            _employeeRepo.Delete(id);
            _employeeRepo.SaveChanges();
        }

        public void Edit(int id, EmployeeUpdateDto obj)
        {
            var employeeModelFromRepository = _employeeRepo.GetEmployeeById(id);
            var employeeModel = _mapper.Map(obj, employeeModelFromRepository);

            _employeeRepo.Edit(employeeModel);
            // we are saving this changes in the database by this line
            _employeeRepo.SaveChanges();
        }

        public IEnumerable<EmployeeReadDto> GetAllEmployees()
        {
            var result = _employeeRepo.GetAllEmployee().ToList();
            return _mapper.Map<IEnumerable<EmployeeReadDto>>(result);
        }

        public EmployeeReadDto GetEmployeeById(int id)
        {
            var result = _employeeRepo.GetEmployeeById(id);
            return _mapper.Map<EmployeeReadDto>(result);
        }

        public void PartialEdit(int id, JsonPatchDocument<EmployeeUpdateDto> jsonPatchDocument)
        {
            var employeeModelFromRepository = _employeeRepo.GetEmployeeById(id);
            var employeeModel = _mapper.Map<EmployeeUpdateDto>(employeeModelFromRepository);

            jsonPatchDocument.ApplyTo(employeeModel);

            var result = _mapper.Map(employeeModel, employeeModelFromRepository);

            _employeeRepo.Edit(result);

            _employeeRepo.SaveChanges();
        }

    }
}
