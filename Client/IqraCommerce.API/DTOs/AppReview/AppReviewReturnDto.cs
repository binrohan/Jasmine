using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class AppReviewReturnDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
