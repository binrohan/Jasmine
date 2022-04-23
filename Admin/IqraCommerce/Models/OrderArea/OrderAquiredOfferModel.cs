using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.OrderArea
{
    public class OrderAquiredOfferModel : DropDownBaseModel
    {
        public Guid OrderId { get; set; }
        public Guid RefOfferId { get; set; }
        public OrderAquiredOfferType TypeOfOffer { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public bool IsRedeemed { get; set; }
        public string Remarks { get; set; }
    }
}
