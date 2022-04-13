using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderToCalcPaymentDto
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public IEnumerable<Guid> ListOfProductId { get; set; }
        public string CouponCode { get; set; }
    }
}