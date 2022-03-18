using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class SubMenuItemAccess
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeLog { get; set; }
        public Guid SubMenuItemId { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid MenuCategoryId { get; set; }
        public Guid ReferenceId { get; set; }
        public int Type { get; set; }
    }
}
