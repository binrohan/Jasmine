namespace IqraCommerce.API.DTOs
{
    public class OrderPaymentDto
    {
        public OrderPaymentDto(double orderValue,
                               double productAmount,
                               double productDiscount,
                               double couponDiscount,
                               double cashback,
                               double[] shippingCharges)
        {
            OrderValue = orderValue;
            ProductAmount = productAmount;
            ProductDiscount = productDiscount;
            CouponDiscount = couponDiscount;
            Cashback = cashback;
            ShippingCharge = shippingCharges[0];
            OriginalShippingCharge = shippingCharges[1];
            PayableAmount = orderValue + shippingCharges[0];

        }
        public double OrderValue { get; set; }
        public double ProductAmount { get; set; }
        public double ProductDiscount { get; set; }
        public double CouponDiscount { get; set; }
        public double Cashback { get; set; }
        public double ShippingCharge { get; set; }
        public double OriginalShippingCharge { get; set; }
        public double PayableAmount { get; set; }
    }
}