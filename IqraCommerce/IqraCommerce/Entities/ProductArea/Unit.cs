using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("Unit")]
    [Alias("unit")]
    public class Unit : DropDownBaseEntity
    {
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
