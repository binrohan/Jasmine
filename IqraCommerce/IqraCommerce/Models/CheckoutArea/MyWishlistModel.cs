using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.CheckoutArea
{
    [Table("MyWishlist")]
    [Alias("mwslst")]
    public partial class MyWishlistModel: AppBaseModel
    {
        public Guid ProductId { get; set; }
        public string Remarks { get; set; }
    }
}
