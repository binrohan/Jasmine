using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.PromotionArea
{
    [Table("Offer")]
    [Alias("offer")]
    public class Offer : DropDownBaseEntity
    {
        public OfferType OfferType { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public string ImageURL { get; set; }
        public bool IsVisible { get; set; }
        public int Rank { get; set; }

    }
}
