using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.CustomerArea
{
    [Table("CustomerPayment")]
    [Alias("ctrpmnt")]
    public class CustomerPayment : AppBaseEntity
    {
        public string OrderNo { get; set; }
        public double Amount { get; set; }
        public string Mobile { get; set; }
    }
}
