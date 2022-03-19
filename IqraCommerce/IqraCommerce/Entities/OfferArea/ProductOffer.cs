using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.OfferArea
{
    [Table("ProductOffer")]
    [Alias("pdctofr")]
    public partial class ProductOffer : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        /// <summary>
        /// Fixed|Percentage|Amount
        /// if a product have a regular price 200 and discount 30. 
        /// when DiscountType Fixed is used then discounted price will be 30.
        /// when DiscountType Percentage is used then discounted price will be 140.
        /// when DiscountType Amount is used then discounted price will be 170.
        /// </summary>
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public string PromoCode { get; set; }
    }
}
