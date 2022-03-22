using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IqraCommerce.Entities.ProductArea
{
    [Table("Category")]
    [Alias("category")]
    public class Category : DropDownBaseEntity
    {
        public bool IsRoot { get; set; }
        public Guid ParentId { get; set; }
        public string ParentName { get; set; }
        public int Rank { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
        public int Depth { get; set; }
        public string Hierarchy { get; set; }
        public bool IsVisibleInHome { get; set; }
    }
}
