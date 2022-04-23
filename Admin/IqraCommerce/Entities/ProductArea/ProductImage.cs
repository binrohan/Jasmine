using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("ProductImage")]
    [Alias("productimage")]
    public class ProductImage : DropDownBaseEntity
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
