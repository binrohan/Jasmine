using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class ActionMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ControllerId { get; set; }
    }
}
