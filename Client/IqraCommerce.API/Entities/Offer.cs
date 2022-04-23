using System;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public class Promotion : BaseEntity
    {
        public PromotionType PromotionType { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public string ImageURL { get; set; }
        public bool IsVisible { get; set; }
        public int Rank { get; set; }
    }
}