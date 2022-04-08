using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ProductImage : BaseEntity
    {
        public string ReferenceId { get; set; }
        public Guid ProductId { get; set; }
        public string ImageURL { get; set; }
        public string IconURL { get; set; }
        public bool IsPrimary { get; set; }
        public string MimeType { get; set; }
        public long Size { get; set; }
    }
}
