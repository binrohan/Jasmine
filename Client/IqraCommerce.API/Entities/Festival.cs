using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public partial class Festival : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rank { get; set; }
        public bool IsVisible { get; set; }
        public IList<FestivalProduct> FestivalProducts { get; set; }
    }
}
