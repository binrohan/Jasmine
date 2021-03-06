using System;

namespace IqraCommerce.API.DTOs
{
    public class CashbackServiceDto
    {
        public CashbackServiceDto()
        {

        }
        public CashbackServiceDto(double cashbackAmount)
        {
            CashbackAmount = cashbackAmount;
            Id = Guid.Empty;
        }
        public CashbackServiceDto(double cashbackAmount, Guid id, double OrderPayment)
        {
            CashbackAmount = cashbackAmount;
            Id = id;
        }
        public Guid Id { get; set; }
        public double CashbackAmount { get; set; }
        public double OrderPayment { get; set; }
    }
}