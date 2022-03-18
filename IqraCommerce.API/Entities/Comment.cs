using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ParentId { get; set; }
        public int ReplyCount { get; set; }
        public int LikeCount { get; set; }
        public int UnLikeCount { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public string ApproveStatus { get; set; }
        public Guid ApprovedBy { get; set; }
        public DateTime ApprovedAt { get; set; }
    }
}
