using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.ProductArea
{
    public class Festival : DropDownBaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rank { get; set; }
        public bool IsVisible { get; set; }

    }
}
