using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.DTOs.Product
{
    public class ProductDescriptionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double CurrentPrice { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
    }
}
