using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.BlogArea
{
    [Table("Blog")]
    [Alias("blg")]
    public partial class Blog : DropDownBaseEntity
    {
        public string PostContent { get; set; }
        public string BlogCategoryId { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
