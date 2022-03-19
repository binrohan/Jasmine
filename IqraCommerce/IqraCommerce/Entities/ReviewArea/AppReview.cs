
using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ReviewArea
{
    [Table("AppReview")]
    [Alias("aprvw")]
    public partial class AppReview : AppBaseEntity
    {
        public Guid ParentId { get; set; }
        public int ReplyCount { get; set; }
        public int LikeCount { get; set; }
        public int UnLikeCount { get; set; }
        public Guid CustomerId { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        /// <summary>
        /// Pending|Approved|Rejected
        /// </summary>
        public string ApproveStatus { get; set; }
        public Guid ApprovedBy { get; set; }
        public DateTime ApprovedAt { get; set; } = DateTime.MaxValue;

    }
}
