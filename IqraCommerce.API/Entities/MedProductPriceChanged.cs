using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class MedProductPriceChanged
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string PriceLabel { get; set; }
        public double Price { get; set; }
        public string PriceLabelB { get; set; }
        public double PriceB { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
