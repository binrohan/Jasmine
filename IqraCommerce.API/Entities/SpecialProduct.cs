using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class SpecialProduct
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid ProductId { get; set; }
        public double Rank { get; set; }
        public string ProductType { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
