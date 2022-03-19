using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.BlogArea
{
    [Table("Blog")]
    [Alias("blg")]
    public partial class BlogModel : DropDownBaseModel
    {
        public string PostContent { get; set; }
        public string BlogCategoryId { get; set; }

    }
}
