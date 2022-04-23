using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ChangeHistory
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid EntityId { get; set; }
        public string ChangeFrom { get; set; }
        public string ChangeType { get; set; }
        public double Amount { get; set; }
        public string Before { get; set; }
        public string Change { get; set; }
        public string After { get; set; }
        public string Info { get; set; }
        public string Transations { get; set; }
    }
}
