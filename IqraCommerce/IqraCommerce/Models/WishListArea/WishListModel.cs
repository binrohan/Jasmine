using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.WishListArea
{
    [Table("WishList")]
    [Alias("wshlst")]
    public partial class WishListModel : AppBaseModel
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>

    }
}
