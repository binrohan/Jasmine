using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class NotificationParamsDto
    {
        public int Index { get; set; } = 1;
        public int Take { get; set; } = 10;
    }
}