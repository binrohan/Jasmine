using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("Product")]
    [Alias("product")]
    public class Product : DropDownBaseEntity
    {
        public string DisplayName { get; set; }
        public string Excerpt { get; set; } 
        public string PackSize { get; set; }

        public string ImageURL { get; set; }

        public double CurrentPrice { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double DiscountedPercentage { get; set; }
        public double TradePrice { get; set; }
        public double SoldTradePrice { get; set; }
        public double Vat { get; set; }
        public bool IsVatFixedType { get; set; }
        public double SoldPrice { get; set; }
        public double Profit { get; set; }

        public int StockUnit { get; set; }
        public int SoldUnit { get; set; }

        public bool IsVisible { get; set; }

        public bool IsInHomePage { get; set; }
        public int Rank { get; set; }

        public double Rating { get; set; }
        public int RatingCount { get; set; }

        public Guid BrandId { get; set; }

        public bool IsUpComming { get; set; }

        public Guid UnitId { get; set; }

        public string SearchQuery { get; set; }

        public bool IsHighlighted { get; set; }
        public string HighlightedImageURL { get; set; }
    }
}
