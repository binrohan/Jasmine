using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class DataImporter
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
        public string FullName { get; set; }
        public string DosageForm { get; set; }
        public string Strength { get; set; }
        public string GenericName { get; set; }
        public string Data { get; set; }
        public string Content { get; set; }
        public string Html { get; set; }
        public string Url { get; set; }
    }
}
