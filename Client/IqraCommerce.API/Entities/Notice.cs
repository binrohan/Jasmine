using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Notice : BaseEntity
    {
        
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsVisible { get; set; }
        public int Rank { get; set; }
    }
}
