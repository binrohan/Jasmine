using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class ProductImageModel : DropDownBaseModel
    {
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public bool IsPrimary { get; set; }
    }
}
