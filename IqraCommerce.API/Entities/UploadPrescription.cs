using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class UploadPrescription
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
        public Guid ShippingId { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string OrderNo { get; set; }
        public string Status { get; set; }
        public int FileCount { get; set; }
        public string IconPath { get; set; }
    }
}
