using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.OrderArea
{
    public class PaymentHistoryModel : DropDownBaseModel
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Reference { get; set; }
        public PaymentMedium Medium { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }

    }
}
