using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class DeviceActivity
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }
        public string UrlReferrer { get; set; }
        public string UserAgent { get; set; }
        public string UserHostAddress { get; set; }
        public string UserHostName { get; set; }
        public string AbsolutePath { get; set; }
        public string AbsoluteUri { get; set; }
        public string Authority { get; set; }
        public string DnsSafeHost { get; set; }
        public string Host { get; set; }
    }
}
