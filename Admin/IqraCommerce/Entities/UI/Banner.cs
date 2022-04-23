using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UI
{
    [Table("Banner")]
    [Alias("banner")]
    public partial class Banner : DropDownBaseEntity
    {
        public string ImageURL { get; set; }
        public string Link { get; set; }
        public double Rank { get; set; }
        /// <summary>
        /// Possible values: large, medium, small
        /// </summary>
        public string Size { get; set; }
        public bool IsVisible { get; set; }
        public BannerType TypeOfBanner { get; set; }
    }
}
