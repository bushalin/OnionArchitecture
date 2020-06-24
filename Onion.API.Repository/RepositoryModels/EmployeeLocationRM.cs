using System;

namespace Onion.API.Repository.RepositoryModels
{
    public class EmployeeLocationRM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string CurrentLocation { get; set; }
    }
}