using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class RewardPointHistory
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid ProductOrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RewardPointId { get; set; }
        public string Status { get; set; }
        public double Point { get; set; }
    }
}
