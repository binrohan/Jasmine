using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ReviewArea
{
    [Table("Rating")]
    [Alias("rtng")]
    public partial class Rating : AppBaseEntity
    {
     
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int RatingCount { get; set; }
        /// <summary>
        /// Number of Customer Rate the product
        /// </summary>
        public int CustomerCount { get; set; }
       
        public double AverageRating { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
