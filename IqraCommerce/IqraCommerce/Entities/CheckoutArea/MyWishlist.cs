
using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.CheckoutArea
{
    [Table("MyWishlist")]
    [Alias("mwslst")]
    public partial class MyWishlist: AppBaseEntity
    {
        public Guid ProductId { get; set; }
    }
}
