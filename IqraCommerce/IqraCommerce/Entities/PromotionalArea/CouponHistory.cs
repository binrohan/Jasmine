using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.PromotionalArea
{
    [Table("CouponHistory")]
    [Alias("cpnhstr")]
    public partial class CouponHistory : AppBaseEntity
    {
        public Guid CouponId { get; set; }
        public Guid CustomerId { get; set; }
        /// <summary>
        /// OrderId is empty at First.
        /// When Order is completed OrderId is filled by order.Id;
        /// </summary>
        public Guid OrderId { get; set; }
        public double CoupenAmount { get; set; }
        public double OrderAmount { get; set; }
        public double OrderDiscount { get; set; }
        /// <summary>
        /// Pending|Applied
        /// </summary>
        public string Status { get; set; }
    }
}
