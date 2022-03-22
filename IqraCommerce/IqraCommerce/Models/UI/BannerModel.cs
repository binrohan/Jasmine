
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
    [Table("Banner")]
    [Alias("bnr")]
    public partial class BannerModel : DropDownBaseModel
    {
        public string ImageURL { get; set; }
        public string Link { get; set; }
        public double Rank { get; set; }
        /// <summary>
        /// Possible values: large, medium, small
        /// </summary>
        public string Size { get; set; }
        public string Remarks { get; set; }
        public bool IsVisible { get; set; }

    }
}
