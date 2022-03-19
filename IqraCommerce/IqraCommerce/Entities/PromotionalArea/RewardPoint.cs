using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.PromotionalArea
{
    [Table("RewardPoint")]
    [Alias("rwrdpnt")]
    public partial class RewardPoint : AppBaseEntity
    {
        public int RewardAmount { get; set; }
        public int OrderAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
      
    }
}
