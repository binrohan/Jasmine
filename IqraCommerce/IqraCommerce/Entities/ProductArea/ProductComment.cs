using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("ProductComment")]
    [Alias("pdctcmnt")]
    public class ProductComment : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public string Comment { get; set; }
        //public int Ratting { get; set; }
    }
}
