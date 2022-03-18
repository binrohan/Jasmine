using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Customer
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
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Cashback { get; set; }
        public double OrderAmountPending { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public Guid Otpid { get; set; }
    }
}
