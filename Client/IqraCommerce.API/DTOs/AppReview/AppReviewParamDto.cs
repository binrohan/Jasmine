using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class AppReviewParamDto
    {
        public int Take { get; set; }
        public int Index { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
