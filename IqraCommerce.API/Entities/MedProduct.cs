using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class MedProduct
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public double ProductId { get; set; }
        public string Strength { get; set; }
        public double GenericId { get; set; }
        public string GenericName { get; set; }
        public string Category { get; set; }
        public double CompanyId { get; set; }
        public string Company { get; set; }
        public string Dosage { get; set; }
        public string OverDosage { get; set; }
        public string Storage { get; set; }
        public string PriceLabel { get; set; }
        public double Price { get; set; }
        public string PackUnit { get; set; }
        public double PackSize { get; set; }
        public double PackMrp { get; set; }
        public string AlsoAs { get; set; }
        public string Content { get; set; }
        public string Html { get; set; }
        public string Url { get; set; }
    }
}
