using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class Contact : BaseEntity
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }
        public string Status { get; set; }
    }
}
