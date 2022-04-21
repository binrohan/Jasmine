using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Activity : BaseEntity
    {

        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
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
