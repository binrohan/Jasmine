using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.EmployeeArea
{
    public class EmployeeModel : DropDownBaseModel
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
