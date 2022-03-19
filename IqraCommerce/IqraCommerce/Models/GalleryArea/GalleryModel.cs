using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.GalleryArea
{
    [Table("Gallery")]
    [Alias("glry")]
    public partial class GalleryModel : DropDownBaseModel
    {
        public string Image { get; set; }
        public int FileCount { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
