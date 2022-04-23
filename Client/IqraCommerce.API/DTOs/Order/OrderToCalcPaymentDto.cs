using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderToCalcPaymentDto : IOrderToCalcPaymentDto
    {
        public Guid AddressId { get; set; }
        public IEnumerable<OrderProductDto> Products { get; set; }
        public string CouponCode { get; set; }
    }
}