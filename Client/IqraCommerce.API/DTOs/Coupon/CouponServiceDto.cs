using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.DTOs
{
    public class CouponServiceDto
    {
        public CouponServiceDto()
        {

        }
        public CouponServiceDto(string code)
        {
            Code = code;
        }
        public bool IsLegit { get; set; }
        public double Discount { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
        public double Value { get; set; }

        public CouponServiceDto SetDiscount(double discount, string message, double value)
        {
            IsLegit = discount > 0.0;
            Discount = discount;
            Message = message;
            Value = value;

            return this;
        }
         public CouponServiceDto SetDiscount(double discount, string message)
        {
            IsLegit = discount > 0.0;
            Discount = discount;
            Message = message;

            return this;
        }
    }
}