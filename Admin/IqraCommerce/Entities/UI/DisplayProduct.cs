using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UI
{
    [Table("DisplayProduct")]
    [Alias("displayproduct")]
    public class DisplayProduct : DropDownBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid DisplayId { get; set; }
        public bool IsVisible { get; set; }
    }
}
