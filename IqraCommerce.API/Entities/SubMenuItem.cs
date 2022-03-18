using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class SubMenuItem
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeLog { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid MenuCategoryId { get; set; }
        public int ActionMethodId { get; set; }
        public int ControllerId { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
    }
}
