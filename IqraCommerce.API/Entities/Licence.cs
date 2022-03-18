using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Licence
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ActivateAt { get; set; }
        public byte[] Content { get; set; }
    }
}
