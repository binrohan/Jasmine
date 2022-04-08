using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public partial class Complain : BaseEntity
    {
        public ComplainType ComplainType { get; set; }
        public string Message { get; set; }
        public ComplainStatus ComplainStatus { get; set; }
    }
}
