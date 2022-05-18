using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Data
{
    public enum BannerType
    {
        MainBanner,
        OfferBanner
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
        Pending, Confirmed, Processing, Delivering, Delivered, CancelledByAdmin, CanclledByCustomer, Returned
    }

    public enum PaymentStatus
    {
        Pending, InitialFromCashback, PartiallyPaid, Paid, PartiallyRefunded, Refunded 
    }

    public enum OrderAction
    {
        Created, StatusChanged, PaymentStatusChanged, CancelledByAdmin, CancelledByCustomer, PaymentEntry
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
        Pending, Added, Cancelled
    }

    public enum PaymentMedium
    {
        Cash
    }

    public enum NotificationType
    {
        OrderPlacedByAdmin, 
        OrderStatusChanged,
        OrderCancelledByAdmin,
        OrderCancelledByCustomer,
        CustomForAll,
        CustomForSpecific,
        CashbackPending,
        CashbackAquired
    }

    public enum NotificationPurpose
    {
        Order, Offer, Product
    }

    public enum ReviewState
    {
        Pending, Accepted, Denied
    }

}
