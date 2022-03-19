﻿using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.BannerArea
{
    [Table("Banner")]
    [Alias("bnr")]
    public partial class Banner : AppBaseEntity
    {
        public string ImagePath { get; set; }
        /// <summary>
        /// DataUrl when click
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// TopBanner|DisplayBanner
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Display Position in the selected sets of data
        /// </summary>
        public double Rank { get; set; }
        /// <summary>
        /// Possible values: large, medium, small
        /// </summary>
        public string Size { get; set; }
    }
}
