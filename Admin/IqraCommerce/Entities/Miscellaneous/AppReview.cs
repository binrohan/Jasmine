using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.Miscellaneous
{
    [Table("AppReview")]
    [Alias("appreview")]
    public class AppReview : DropDownBaseEntity
    {
        public string Content { get; set; }
        public ReviewState StateOfReview { get; set; }
        public Guid CustomerId { get; set; }
    }
}
