using System;
using System.Collections.Generic;
using IqraCommerce.API.Data;

namespace IqraCommerce.API.Entities
{
    public partial class Customer : BaseEntity
    {
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DueAmount { get; set; }
        public string Cashback { get; set; }
        public IEnumerable<CustomerAddress> Addresses { get; set; }
    }
}
