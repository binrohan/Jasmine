using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.ProductArea
{
    public class FestivalModel : DropDownBaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rank { get; set; }
        public bool IsVisible { get; set; }
        public string Remarks { get; set; }
    }
}
