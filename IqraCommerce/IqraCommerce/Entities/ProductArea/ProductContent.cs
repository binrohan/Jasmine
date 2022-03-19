using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("ProductContent")]
    [Alias("pdctcnt")]
    public class ProductContent:AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public string Content { get; set; }
    }
}
