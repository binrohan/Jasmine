using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.OrderArea
{
    [Table("PaymentHistory")]
    [Alias("paymenthistory")]
    public class PaymentHistory : DropDownBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Reference { get; set; }
        public PaymentMedium Medium { get; set; }
        public double Amount { get; set; }
        public bool ActionIsRefunding { get; set; }
    }
}
