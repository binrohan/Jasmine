using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class Category : BaseEntity
    {
        public bool IsRoot { get; set; }
        public Guid ParentId { get; set; }
        public string ParentName { get; set; }
        public int Rank { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
        public int Depth { get; set; }
        public bool IsVisibleInHome { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}