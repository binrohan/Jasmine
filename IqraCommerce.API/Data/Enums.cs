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
}