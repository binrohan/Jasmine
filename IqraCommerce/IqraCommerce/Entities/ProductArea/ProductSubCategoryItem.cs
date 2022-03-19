using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("ProductSubCategoryItem")]
    [Alias("pdctsbctgritm")]
    public class ProductSubCategoryItem:AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid SubCategoryId { get; set; }
        /// <summary>
        /// Position in the ProductSubCategory
        /// </summary>
        public double Rank { get; set; }
    }
}
