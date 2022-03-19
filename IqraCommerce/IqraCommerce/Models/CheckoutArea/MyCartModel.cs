using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.CheckoutArea
{
    [Table("MyCart")]
    [Alias("mcrt")]
    public partial class MyCartModel : AppBaseModel
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public double Position { get; set; }
    }
}
