using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class UnitModel : DropDownBaseModel
    {
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
    }
}
