using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Perks
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IconPath { get; set; }
        public string Type { get; set; }
        public double Rank { get; set; }
    }
}
