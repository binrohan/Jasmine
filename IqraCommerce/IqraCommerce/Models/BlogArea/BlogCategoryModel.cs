using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.BlogArea
{
    [Table("BlogCategory")]
    [Alias("blgctg")]
    public partial class BlogCategoryModel : DropDownBaseModel
    {
        public string Description { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>

    }
}
