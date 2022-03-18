using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Access : BaseEntity
    {
        
        public string ChangeLog { get; set; }
        public int ActionMethodId { get; set; }
        public Guid RelativeId { get; set; }
        public int AccessType { get; set; }
    }
}
