using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class OrderAquiredOffer : BaseEntity
    {
        public Guid RefOfferId { get; set; }
        public OrderAquiredOfferType TypeOfOffer { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public bool IsRedeemed { get; set; }
    }
}
