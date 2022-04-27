using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class OrderParamsDto
    {
        public int Index { get; set; } = 1;
        public bool IsDecending { get; set; } = true;
       public string Search { get; set; }
       public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}