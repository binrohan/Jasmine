
using IqraBase.Data.Entities;
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.UI
{
    public partial class ShowcaseModel : DropDownBaseModel
    {
        public double Rank { get; set; }
        public string Remarks { get; set; }
        public bool IsVisible { get; set; }

    }
}
