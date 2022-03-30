using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class FestivalProductModel : DropDownBaseModel
    {
        public Guid ProductId { get; set; }
        public Guid FestivalId { get; set; }
    }
}
