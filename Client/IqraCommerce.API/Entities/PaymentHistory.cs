using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class PaymentHistory : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Reference { get; set; }
        public PaymentMedium Medium { get; set; }
        public double Amount { get; set; }
    }
}
