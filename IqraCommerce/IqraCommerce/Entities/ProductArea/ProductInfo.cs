using IqraBase.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("ProductInfo")]
    [Alias("pdctinf")]
    public class ProductInfo
    {
        /// <summary>
        /// ProductId = Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Rating { get; set; }
        /// <summary>
        /// Total Users who rate
        /// </summary>
        public int RatingUser { get; set; }
    }
}
