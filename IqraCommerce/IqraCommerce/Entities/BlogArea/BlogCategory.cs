using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.BlogArea
{
    [Table("BlogCategory")]
    [Alias("blgctg")]
    public partial class BlogCategory : DropDownBaseEntity
    {
        public string Description { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>

    }
}
