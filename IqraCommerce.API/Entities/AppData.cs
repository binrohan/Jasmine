using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class AppData
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeLog { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Selector { get; set; }
        public string From { get; set; }
        public string GroupBy { get; set; }
        public string Summary { get; set; }
        public string Daily { get; set; }
        public string Fields { get; set; }
        public string DateFields { get; set; }
        public string SortBy { get; set; }
        public bool IsDesending { get; set; }
        public string Remarks { get; set; }
    }
}
