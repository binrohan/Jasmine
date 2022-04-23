using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Device : BaseEntity
    {

        public Guid UserId { get; set; }
        public string AppName { get; set; }
        public string Language { get; set; }
        public string Platform { get; set; }
        public string UserAgent { get; set; }
        public bool HasAccess { get; set; }
        public string AccessType { get; set; }
    }
}
