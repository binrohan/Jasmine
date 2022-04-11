using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.UserArea
{
    [Table("Customer")]
    [Alias("customer")]
    public partial class Customer : DropDownBaseEntity
    {
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double DueAmount { get; set; }
        public double Cashback { get; set; }
        public RegistrationBy RegistrationBy { get; set; }
    }
}
