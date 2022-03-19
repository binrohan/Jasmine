using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ProductArea
{
    [Table("DealsOfTheWeek")]
    [Alias("dlswk")]
    public partial class DealsOfTheWeek : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public double Rank { get; set; }
        public DateTime From { get; set; } = DateTime.Now;
        public DateTime To { get; set; } = DateTime.MaxValue;
    }
}
