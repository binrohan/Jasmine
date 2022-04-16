using System;

namespace IqraCommerce.API.DTOs
{
    public class OrderProductReturnDto
    {
        public Guid Id { get; set; }
        public Guid RefProductId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string PackSize { get; set; }
        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }
    }
}