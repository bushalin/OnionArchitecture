using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Onion.API.Model.DTOs;
using Onion.API.Model.DTOs.Location;
using Onion.API.Model.Employee;
using Onion.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.API.Services.Location
{
    public class LocationServices : ILocationServices
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _repository;

        public LocationServices(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _repository = locationRepository;
        }

        #region BASIC_CRUD

        public IEnumerable<LocationReadDto> GetAllLocations()
        {
            var result = _repository.GetAll();

            return (_mapper.Map<List<LocationReadDto>>(result));
        }

        public IEnumerable<EmployeeLocationDto> GetEmployeeLocations()
        {
            var result = _repository.GetEmployeeLocations().ToList();
            return (_mapper.Map<List<EmployeeLocationDto>>(result));
        }

        public EmployeeLocationDto GetLocationByEmployeeId(Guid employeeId)
        {
            var result = _repository.GetByEmployeeId(employeeId);
            return (_mapper.Map<EmployeeLocationDto>(result));
        }

        public LocationReadDto GetLocationById(Guid id)
        {
            var result = _repository.GetById(id);
            return (_mapper.Map<LocationReadDto>(result));
        }

        public LocationReadDto CreateLocation(LocationCreateDto obj)
        {
            var model = _mapper.Map<LocationModel>(obj);

            _repository.Insert(model);
            _repository.SaveChanges();

            return (_mapper.Map<LocationReadDto>(model));
        }

        public void LocationEdit(Guid id, LocationUpdateDto obj)
        {
            var locationFromRepository = _repository.GetById(id);
            var locationModel = _mapper.Map(obj, locationFromRepository);

            _repository.Update(locationModel);
            _repository.SaveChanges();
        }

        public void PartialLocationUpdate(Guid id, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        {
            var locationFromRepository = _repository.GetById(id);
            var locationModel = _mapper.Map<LocationUpdateDto>(locationFromRepository);

            jsonPatchDocument.ApplyTo(locationModel);

            var result = _mapper.Map(locationModel, locationFromRepository);

            //_repository.Update(result);
            _repository.SaveChanges();
        }

        public void DeleteLocation(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        #endregion BASIC_CRUD

        public void PartialLocationUpdateByEmployeeId(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        {
            var locationFromRepository = _repository.GetLocationByEmployeeId(employeeId);
            var locationModel = _mapper.Map<LocationUpdateDto>(locationFromRepository);

            jsonPatchDocument.ApplyTo(locationModel);

            var result = _mapper.Map(locationModel, locationFromRepository);

            _repository.UpdateLocationState(result);
            _repository.SaveChanges();
        }
    }
}