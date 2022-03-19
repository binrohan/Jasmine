using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.CheckoutArea
{
    [Table("MyCart")]
    [Alias("mcrt")]
    public partial class MyCart : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public double Position { get; set; }
    }
}
