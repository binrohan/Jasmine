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
        New, Read, XXX, OnHold
    }

    public enum OfferType
    { 
        Cashback, Delivery
    }

}
