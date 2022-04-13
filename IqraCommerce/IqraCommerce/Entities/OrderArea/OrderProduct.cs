using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.OrderArea
{
    [Table("OrderProduct")]
    [Alias("orderproduct")]
    public class OrderProduct : DropDownBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid RefProductId { get; set; }
        
        public string DisplayName { get; set; }
        public string PackSize { get; set; }
        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }
    }
}
