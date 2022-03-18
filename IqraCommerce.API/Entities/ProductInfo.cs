using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ProductInfo
    {
        public Guid Id { get; set; }
        public double Rating { get; set; }
        public int RatingUser { get; set; }
    }
}
