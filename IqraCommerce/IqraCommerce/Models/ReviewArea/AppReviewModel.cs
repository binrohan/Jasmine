
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ReviewArea
{
    [Table("AppReview")]
    [Alias("aprvw")]
    public partial class AppReviewModel : AppBaseModel
    {
        public Guid ParentId { get; set; }
        public Guid ReplyCount { get; set; }
        public Guid LikeCount { get; set; }
        public Guid UnLikeCount { get; set; }
        public Guid CustomerId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>
        /// <summary>
        /// Pending|Approved|Rejected
        /// </summary>
        public string ApproveStatus { get; set; }
        public Guid ApprovedBy { get; set; }
        public DateTime ApprovedAt { get; set; }

    }
}
