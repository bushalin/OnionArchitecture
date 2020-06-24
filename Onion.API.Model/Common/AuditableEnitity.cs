using System;

namespace Onion.API.Model.Common
{
    public class AuditableEnitity : BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}