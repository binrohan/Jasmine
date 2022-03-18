using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Notice
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public string NoticeContent { get; set; }
        public DateTime ActiveAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; }
        public int Rank { get; set; }
    }
}
