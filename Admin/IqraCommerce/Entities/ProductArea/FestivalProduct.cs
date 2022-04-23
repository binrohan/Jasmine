using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("FestivalProduct")]
    [Alias("FestivalProduct")]
    public class FestivalProduct : DropDownBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid FestivalId { get; set; }
    }
}
