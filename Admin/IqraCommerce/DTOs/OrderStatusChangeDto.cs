using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs
{
    public class OrderStatusChangeDto
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }

    }
}
