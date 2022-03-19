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
    [Table("SafetyAdvice")]
    [Alias("sftdvc")]
    public class SafetyAdvice : AppBaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid SafetyItemId { get; set; }
        public Guid SafetyLabelId { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }
    }
}
