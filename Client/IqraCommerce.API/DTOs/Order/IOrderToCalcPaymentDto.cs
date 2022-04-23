using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public interface IOrderToCalcPaymentDto
    {
        Guid AddressId { get; set; }
        IEnumerable<OrderProductDto> Products { get; set; }
        string CouponCode { get; set; }
    }
}