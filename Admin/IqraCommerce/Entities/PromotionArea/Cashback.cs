using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Entities.PromotionArea
{
    [Table("Cashback")]
    [Alias("cashback")]
    public class Cashback : DropDownBaseEntity
    {
        public DateTime StartingAt { get; set; }
        public DateTime EndingAt { get; set; }
        public bool IsPublished { get; set; }
        public double MinOrderValue { get; set; }
        public double Amount { get; set; }
    }
}
