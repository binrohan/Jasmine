using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Device
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public string AppName { get; set; }
        public string Language { get; set; }
        public string Platform { get; set; }
        public string UserAgent { get; set; }
        public bool HasAccess { get; set; }
        public string AccessType { get; set; }
        public string Remarks { get; set; }
    }
}
