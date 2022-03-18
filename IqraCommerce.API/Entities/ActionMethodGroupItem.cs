using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ActionMethodGroupItem
    {
        public int Id { get; set; }
        public int ActionMethodId { get; set; }
        public Guid ActionMethodGroupId { get; set; }
    }
}
