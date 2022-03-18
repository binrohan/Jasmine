using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class OrderShipping
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
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public int UnionId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
