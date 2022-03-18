using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ActionMethodGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeLog { get; set; }
        public string Description { get; set; }
    }
}
