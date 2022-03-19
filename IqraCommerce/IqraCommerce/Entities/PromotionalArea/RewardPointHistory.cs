using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.PromotionalArea
{
    [Table("RewardPointHistory")]
    [Alias("rwrdhstr")]
    public partial class RewardPointHistory : AppBaseEntity
    {
        public Guid ProductOrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RewardPointId { get; set; }
        /// <summary>
        /// Approved - When Order Status is Delivered
        /// Pending - When Order Status is Initiated|Processing|On Shipping
        /// Rejected - When Order Status is Canceled By Admin|Canceled By Customer|Returned
        /// </summary>
        public string Status { get; set; }
        public double Point { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>

    }
}
