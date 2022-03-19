using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ProductOrderArea
{
    [Table("ProductOrderStatusHistory")]
    [Alias("pdctodrstshstr")]
    public partial class ProductOrderStatusHistory : AppBaseEntity
    {
        public Guid OrderId { get; set; }
        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; }
        public string StatusChangeReason { get; set; }
    }
}
