using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderCreateDto : IOrderToCalcPaymentDto
    {
        public Guid AddressId { get; set; }
        public string CouponCode { get; set; }
        public IEnumerable<OrderProductDto> Products { get; set; }
        public OrderPaymentDto Payment { get; set; }
        public Guid ActivityId { get; set; }
        public string Remarks { get; set; }
    }
}