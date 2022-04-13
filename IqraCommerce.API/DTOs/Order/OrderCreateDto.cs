using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderCreateDto 
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public string CouponCode { get; set; }
        public IList<OrderProductDto> ListOfProductId { get; set; }
    }
}