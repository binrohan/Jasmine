using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("Review")]
    [Alias("review")]
    public class Review : DropDownBaseEntity
    {
        public string Content { get; set; }
        public Guid ProductId { get; set; }
        public ReviewState StateOfReview { get; set; }
    }
}
