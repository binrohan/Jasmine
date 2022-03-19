using IqraBase.Data;
using IqraBase.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.UrgentOrderArea
{
    [Table("UrgentOrder")]
    [Alias("urgntordr")]
    public partial class UrgentOrderModel : DropDownBaseModel
    {
        public string Quantity { get; set; }
        public string ProductPrice { get; set; }
        public string Prescription { get; set; }
        public string CustomerName { get; set; }
        public int Mobile { get; set; }

    }
}
