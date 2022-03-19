using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.RequestOrderArea
{
    [Table("RequestOrder")]
    [Alias("rqstordr")]
    public partial class RequestOrderModel : DropDownBaseModel
    {
        public Guid CustomerId { get; set; }
        public string OrderNo { get; set; }
        public double TotalItem { get; set; }
        public double TotalQuantity { get; set; }
        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; } = "Initiated";
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public string Remarks { get; set; }
        public List<RequestOrderItemModel> Items { get; set; }
        public List<Guid> ImgId { get; set; }

    }
}
