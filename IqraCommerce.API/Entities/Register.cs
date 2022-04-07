using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class Register : BaseEntity
    {
        public string OTP { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsPassed { get; set; }
        public Guid CustomerId { get; set; } = Guid.Empty;
    }
}
