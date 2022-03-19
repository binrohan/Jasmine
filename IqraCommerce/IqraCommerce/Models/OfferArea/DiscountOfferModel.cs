using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.OfferArea
{
    [Table("DiscountOffer")]
    [Alias("dscntofr")]
    public class DiscountOfferModel : AppBaseModel
    {
        /// <summary>
        /// Delivery|Cashback|FirstPurchase
        /// </summary>
        public string OfferType { get; set; }
        /// <summary>
        /// Fixed|Percentage(%)
        /// </summary>
        public string DiscountType { get; set; }
        public double Discount { get; set; }
        public double LeastAmount { get; set; }
        public string ContentHeader { get; set; }
        public string Content { get; set; }
        public string Remarks { get; set; }
    }
}
