using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class PaymentTracker
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid LogId { get; set; }
        public DateTime ChangedAt { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
