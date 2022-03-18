using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Notification
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ReferenceId { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
