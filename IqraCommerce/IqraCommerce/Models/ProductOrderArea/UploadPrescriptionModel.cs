﻿using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.ProductOrderArea
{
    [Table("UploadPrescription")]
    [Alias("upldprscrpt")]
    public partial class UploadPrescriptionModel : AppBaseModel
    {
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Address will be stored in tbl.OrderShipping
        /// currently not using
        /// </summary>
        public Guid ShippingId { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Full Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Auto Generated
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// Initiated|Processing|On Shipping|Delivered|Canceled By Admin|Canceled By Customer|
        /// </summary>
        public string Status { get; set; } = "Initiated";
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
    }
}