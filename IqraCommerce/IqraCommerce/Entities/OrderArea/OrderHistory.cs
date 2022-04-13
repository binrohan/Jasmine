using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.OrderArea
{
    [Table("OrderHistory")]
    [Alias("orderhistory")]
    public class OrderHistory : DropDownBaseEntity
    {
        public Guid OrderId { get; set; }
        public OrderAction TypeOfAction { get; set; }
    }
}
