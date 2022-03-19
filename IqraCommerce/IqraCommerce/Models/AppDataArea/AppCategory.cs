using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.AppDataArea
{
    [Table("AppCategory")]
    [Alias("apctgr")]
    public partial class AppCategoryModel : DropDownBaseModel
    {
        public string ImagePath { get; set; }
        public string Remarks { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
        public Guid ActivityId { get; set; }
    }
}
