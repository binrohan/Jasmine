using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class Brand : BaseEntity
    {
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}