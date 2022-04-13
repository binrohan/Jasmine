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
        New, Read, XXX, OnHold
    }

    public enum OfferType
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
        Pending, PartiallyPaid, Paid, PartiallyRefunded, Refunded
    }

    public enum OrderAction
    {
        StatusChanged, PaymentStatusChanged, Cancelled
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
}