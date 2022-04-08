using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.PromotionArea
{
    public class OfferModel : DropDownBaseModel
    {
        public OfferType OfferType { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public bool IsVisible { get; set; }
        public string Remarks { get; set; }
        public int Rank { get; set; }


    }
}
