using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.PromotionalArea
{
    [Table("RewardPointHistory")]
    [Alias("rwrdhstr")]
    public partial class RewardPointHistoryModel : AppBaseModel
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
        public Guid ActivityId { get; set; }
    }
}
