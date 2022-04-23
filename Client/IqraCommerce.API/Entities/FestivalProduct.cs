using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public class FestivalProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid FestivalId { get; set; }
        public Festival Festival { get; set; }
    }
}
