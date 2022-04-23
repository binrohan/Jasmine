using System.Collections.Generic;
using System.Linq;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Extensions
{
    public static class PaymentCalculation
    {
        public static double Amount(this IEnumerable<Product> products,
                                    IEnumerable<OrderProductDto> orderProducts)
        {
            return products.Sum(p => p.OriginalPrice
                                     * orderProducts
                                        .FirstOrDefault(op => op.Id == p.Id)?
                                        .Quantity ?? 0.0);
        }

        public static double Discount(this IEnumerable<Product> products,
                                        IEnumerable<OrderProductDto> orderProducts)
        {
            return products.Sum(p => p.DiscountedPrice 
                                        * orderProducts
                                        .FirstOrDefault(op => op.Id == p.Id)?
                                        .Quantity ?? 0.0);
        }

        public static double Value(this IEnumerable<Product> products,
                                    IEnumerable<OrderProductDto> orderProducts)
        {
            return products.Sum(p => p.CurrentPrice
                                        * orderProducts
                                        .FirstOrDefault(op => op.Id == p.Id)?
                                        .Quantity ?? 0.0);
        }

        public static double[] ShippingCharge(this CustomerAddress address, double orderValue)
        {
            double[] charges = new double[2];
            District district = address.District;

            charges[1] = district.ShippingCharge;

            charges[0] = district.LowerBounderForMinShippingCharge <= orderValue ?
             district.MinShippingCharge : district.ShippingCharge;

            return charges;
        }
    }
}