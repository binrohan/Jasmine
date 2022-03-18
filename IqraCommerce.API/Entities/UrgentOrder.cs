using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class UrgentOrder
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string ProductPrice { get; set; }
        public string Prescription { get; set; }
        public string CustomerName { get; set; }
        public int Mobile { get; set; }
    }
}
