using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class AppCategoryProduct : BaseEntity
    {
        
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public double Rank { get; set; }
    }
}
