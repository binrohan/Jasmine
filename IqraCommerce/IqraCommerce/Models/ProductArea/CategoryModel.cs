using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class CategoryModel : DropDownBaseModel
    {
        public bool IsRoot { get; set; }
        public Guid ParentId { get; set; }
        public string ParentName { get; set; }
        public int Rank { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
        public string Remarks { get; set; }
        public int Depth { get; set; }
        public string Hierarchy { get; set; }
    }
}
