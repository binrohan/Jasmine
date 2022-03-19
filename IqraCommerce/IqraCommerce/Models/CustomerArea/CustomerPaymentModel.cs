using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.CustomerArea
{
    [Table("CustomerPayment")]
    [Alias("ctrpmnt")]
    public partial class CustomerPaymentModel : AppBaseModel
    {
        public string OrderNo { get; set; }
        public double Amount { get; set; }
        public string Mobile { get; set; }
        public string Remarks { get; set; }

    }
}
