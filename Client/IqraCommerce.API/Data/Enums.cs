namespace IqraCommerce.API.Data
{
    public enum BannerType
    {
        MainBanner,
        OfferBanner
    }

    public enum OrderBy
    {
        Rank,
        Name,
        Discount,
        CreationDate
    }

    public enum AddressType
    {
        Home, Office, HomeTown, Recent
    }

    public enum ComplainType
    {
        Website, Delivery, AgentBehaviors, Products, Others
    }

    public enum ComplainStatus
    {
        New, Seen, OnHold
    }

    public enum PromotionType
    { 
        Cashback, Coupon, Delivery
    }

    public enum RegistrationBy
    { 
       Customer, Admin
    }

    public enum OrderStatus
    {
        Pending, Confirmed, Processing, Delivering, Delivered, Cancelled
    }

    public enum PaymentStatus
    {
        Pending, InitialFromCashback, PartiallyPaid, Paid, PartiallyRefunded, Refunded 
    }

    public enum OrderAction
    {
        Created, StatusChanged, PaymentStatusChanged, CancelledByAdmin,  CancelledByCustomer
    }

    public enum PaymentMethod
    {
        CashOnDelivery
    }

    public enum PlatformType
    {
        Web, Mobile
    }

    public enum OrderAquiredOfferType
    {
        Cashback, Coupon, Delivery, Product
    }

    public enum CashbackRegisterStatus
    {
        Pending, Added, Cancelled, Null
    }
    public enum PaymentMedium
    {
        Cash, Cashback
    }

    public enum NotificationType
    {
        OrderPlacedByAdmin,
        OrderPlacedByCustomer, 
        OrderStatusChanged, 
        OrderCancelledByAdmin, 
        OrderCancelledByCustomer, 
        CustomForAll, 
        CustomForSpecific
    }
}