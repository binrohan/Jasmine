
using IqraBase.Data.Entities;
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqraCommerce.Data;

namespace EBonik.Data.Models.UI
{
    public class DisplayModel : DropDownBaseModel
    {
        public int Rank { get; set; }
        public bool IsVisible { get; set; }
        public string Remarks { get; set; }
    }
}
