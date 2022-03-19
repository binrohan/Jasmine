using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.WishListArea
{
    [Table("WishList")]
    [Alias("wshlst")]
    public partial class WishList : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Device Activity
        /// </summary>
    }
}
