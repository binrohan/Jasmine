using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class RequestOrder
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public string OrderNo { get; set; }
        public double TotalItem { get; set; }
        public double TotalQuantity { get; set; }
        public string Status { get; set; }
        public int FileCount { get; set; }
        public string IconPath { get; set; }
        public string StatusChangeReason { get; set; }
    }
}
