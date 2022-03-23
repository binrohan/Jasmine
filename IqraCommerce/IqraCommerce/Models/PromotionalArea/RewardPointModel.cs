﻿using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.PromotionalArea
{
    [Table("RewardPoint")]
    [Alias("rwrdpnt")]
    public partial class RewardPointModel : AppBaseModel
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