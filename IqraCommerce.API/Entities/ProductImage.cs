using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public bool IsPrimary { get; set; }
    }
}
