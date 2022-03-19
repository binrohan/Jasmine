using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("ProductSubCategory")]
    [Alias("pdctsbctgr")]
    public partial class ProductSubCategory : DropDownBaseEntity
    {
        public Guid ProductCategoryId { get; set; }
        public double Rank { get; set; }
    }
}
