namespace IqraCommerce.API.DTOs
{
    public class PaymentDto
    {
        public double OrderValue { get; set; }
        public double ProductAmount { get; set; }
        public double ProductDiscount { get; set; }
        public double CouponDiscount { get; set; }
        public double CouponValue { get; set; }
        public string CouponMessage { get; set; }
        public double Cashback { get; set; }
        public double ShippingCharge { get; set; }
        public double OriginalShippingCharge { get; set; }
        public double PayableAmount { get; set; }
    }
}