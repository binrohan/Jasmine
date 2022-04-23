using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("Brand")]
    [Alias("brand")]
    public class Brand : DropDownBaseEntity
    {
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
