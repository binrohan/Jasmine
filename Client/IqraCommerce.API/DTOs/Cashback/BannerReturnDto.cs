using System;

namespace IqraCommerce.API.DTOs
{
    public class CashbackServiceDto
    {
        public Guid Id { get; set; }
        public double CashbackAmount { get; set; }
        public bool IsLegit { get; set; }
        public bool Message { get; set; }
    }
}