using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductOrderArea
{
    [Table("ProductOrderItem")]
    [Alias("pdctodritm")]
    public partial class ProductOrderItem : AppBaseEntity
    {
        public Guid ProductOrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public double PayableAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountTotal { get; set; }
    }
}
