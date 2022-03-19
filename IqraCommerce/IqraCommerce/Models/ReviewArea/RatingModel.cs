
using System;
using System.ComponentModel.DataAnnotations.Schema;
using IqraBase.Data;
using IqraBase.Data.Models;

namespace EBonik.Data.Models.ReviewArea
{
    [Table("Rating")]
    [Alias("rtng")]
    public partial class RatingModel : AppBaseModel
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
