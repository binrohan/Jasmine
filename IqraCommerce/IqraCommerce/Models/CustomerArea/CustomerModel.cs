
using IqraBase.Data.Entities;
using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqraCommerce.Data;

namespace EBonik.Data.Models.UserArea
{
    public class CustomerModel : DropDownBaseModel
    {
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DueAmount { get; set; }
        public string Cashback { get; set; }
    }
}
