using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.API.Model.Common
{
    public class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}