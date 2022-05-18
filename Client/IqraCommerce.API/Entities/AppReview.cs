using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class AppReview : BaseEntity
    {
        public string Content { get; set; }
        public ReviewState StateOfReview { get; set; }
    }
}

