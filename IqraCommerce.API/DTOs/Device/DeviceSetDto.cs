using System;
using System.Collections;
using System.Collections.Generic;

namespace IqraCommerce.API.DTOs
{
    public class DeviceSetDto
    {
        public Guid UserId { get; set; }
        public string AppName { get; set; }
        public string Language { get; set; }
        public string Platform { get; set; }
        public string UserAgent { get; set; }
    }
}