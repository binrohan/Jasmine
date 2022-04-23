using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("ProductCategory")]
    [Alias("productcategory")]
    public class ProductCategory : DropDownBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
