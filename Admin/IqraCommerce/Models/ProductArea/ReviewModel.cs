using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class ReviewModel : DropDownBaseModel
    {
        public string Content { get; set; }
        public ReviewState StateOfReview { get; set; }
        public Guid ProductId { get; set; }
        public string Remarks { get; set; }
    }
}
