using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.OrderArea
{
    public class OrderProductModel : DropDownBaseModel
    {
        public Guid OrderId { get; set; }
        public Guid RefProductId { get; set; }

        public string DisplayName { get; set; }
        public string PackSize { get; set; }
        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }

        public int Quantity { get; set; }

        public double Amount { get; set; }
        public double Discount { get; set; }
        public string Remarks { get; set; }
    }
}
