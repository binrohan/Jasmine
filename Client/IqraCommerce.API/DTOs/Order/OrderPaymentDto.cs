namespace IqraCommerce.API.DTOs
{
    public class OrderPaymentDto
    {
        public OrderPaymentDto()
        {
            
        }
        public OrderPaymentDto(double orderValue,
                               double productAmount,
                               double productDiscount,
                               CouponServiceDto coupon,
                               CashbackServiceDto cashback,
                               double[] shippingCharges)
        {
            OrderValue = orderValue;
            ProductAmount = productAmount;
            ProductDiscount = productDiscount;
            Coupon = coupon;
            Cashback = cashback;
            ShippingCharge = shippingCharges[0];
            OriginalShippingCharge = shippingCharges[1];
            PayableAmount = orderValue + shippingCharges[0] - coupon.Discount;

        }
        public double OrderValue { get; set; }
        public double ProductAmount { get; set; }
        public double ProductDiscount { get; set; }
        public CouponServiceDto Coupon { get; set; }
        public CashbackServiceDto Cashback { get; set; }
        public double ShippingCharge { get; set; }
        public double OriginalShippingCharge { get; set; }
        public double PayableAmount { get; set; }
    }
}