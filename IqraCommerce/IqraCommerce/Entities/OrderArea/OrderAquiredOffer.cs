using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.OrderArea
{
    [Table("OrderAquiredOffer")]
    [Alias("orderaquiredoffer")]
    public class OrderAquiredOffer : DropDownBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid RefOfferId { get; set; }
        public OrderAquiredOfferType TypeOfOffer { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public bool IsRedeemed { get; set; }
    }
}
