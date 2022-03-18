using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class DiscountOffer
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public string OfferType { get; set; }
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public double LeastAmount { get; set; }
        public string ContentHeader { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public double Rank { get; set; }
    }
}
