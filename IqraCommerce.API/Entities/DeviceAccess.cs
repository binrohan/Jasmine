using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class DeviceAccess
    {
        public Guid Id { get; set; }
        public Guid AccessDeviceId { get; set; }
        public Guid CreatorDeviceId { get; set; }
        public bool HasAccess { get; set; }
        public string AccessType { get; set; }
        public string Remarks { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
