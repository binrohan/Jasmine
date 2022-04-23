using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs.Product
{
    public class ProductHighlightDto
    {
        public Guid ProductId { get; set; }
        public Guid ActivityId { get; set; } = Guid.Empty;

    }
}
