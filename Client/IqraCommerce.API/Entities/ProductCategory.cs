using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ProductCategory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
