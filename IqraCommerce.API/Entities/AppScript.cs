using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class AppScript
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeLog { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public string FilePath { get; set; }
        public string Content { get; set; }
        public string Remarks { get; set; }
    }
}
