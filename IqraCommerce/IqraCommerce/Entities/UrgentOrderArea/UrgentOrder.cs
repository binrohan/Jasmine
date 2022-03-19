using IqraBase.Data;
using IqraBase.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.UrgentOrderArea
{
    [Table("UrgentOrder")]
    [Alias("urgntordr")]
    public partial class UrgentOrder : DropDownBaseEntity
    {
        public string Quantity { get; set; }
        public string ProductPrice { get; set; }
        public string Prescription { get; set; }
        public string CustomerName { get; set; }
        public int Mobile { get; set;}

    }
}
