using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("SpecialProduct")]
    [Alias("spclpdct")]
    public partial class SpecialProduct : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public double Rank { get; set; }
        public string ProductType { get; set; }
        public DateTime From { get; set; } = DateTime.Now;
        public DateTime To { get; set; } = DateTime.MaxValue;
    }
}
