using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("ProductImage")]
    [Alias("productimage")]
    public class ProductImage : DropDownBaseEntity
    {
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public bool IsPrimary { get; set; }
    }
}
