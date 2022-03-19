using EBonik.Data.Models.PromotionalArea;
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.ProductOrderArea
{
    [Table("ProductOrderStatusHistory")]
    [Alias("pdctodrstshstr")]
    public partial class ProductOrderStatusHistoryModel : AppBaseModel
    {
        public ProductOrderStatusHistoryModel() { }
        public ProductOrderStatusHistoryModel(Guid orderId, string status, string statusChangeReason) {
            OrderId = orderId;
            Status = status;
            StatusChangeReason = statusChangeReason;
        }
        public Guid OrderId { get; set; }
        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; }
        public string StatusChangeReason { get; set; }
    }
}
