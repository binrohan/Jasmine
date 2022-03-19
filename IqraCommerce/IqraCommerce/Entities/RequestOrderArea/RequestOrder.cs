using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.RequestOrderArea
{
    [Table("RequestOrder")]
    [Alias("rqstordr")]
    public partial class RequestOrder : AppBaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public string OrderNo { get; set; }
        public double TotalItem { get; set; }
        public double TotalQuantity { get; set; }
        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; }
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public string StatusChangeReason { get; set; }
    }
}
