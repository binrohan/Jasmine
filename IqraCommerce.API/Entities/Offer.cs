using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Offer : BaseEntity
    {
        public OfferType OfferType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingAt { get; set; }
        public string ImageURL { get; set; }
        public bool IsVisible { get; set; }
    }
}