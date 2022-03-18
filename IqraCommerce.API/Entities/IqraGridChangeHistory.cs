using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class IqraGridChangeHistory
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeLog { get; set; }
        public Guid ChangeId { get; set; }
        public string ChangeType { get; set; }
        public string RelationType { get; set; }
        public Guid RelativeId { get; set; }
        public string Content { get; set; }
    }
}
