using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Thana
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
        public Guid DistictId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
