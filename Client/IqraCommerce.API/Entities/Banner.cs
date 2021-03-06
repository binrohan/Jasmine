using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public partial class Banner : BaseEntity
    {

         public string ImageURL { get; set; }
        public string Link { get; set; }
        public double Rank { get; set; }
        public string Size { get; set; }
        public bool IsVisible { get; set; }
        public BannerType TypeOfBanner { get; set; }
    }
}
