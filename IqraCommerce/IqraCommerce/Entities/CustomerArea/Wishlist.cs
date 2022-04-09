using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UserArea
{
    [Table("Wishlist")]
    [Alias("wishlist")]
    public partial class Wishlist : DropDownBaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
