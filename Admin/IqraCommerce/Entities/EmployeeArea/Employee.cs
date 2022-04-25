using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.EmployeeArea
{
    [Table("Employee")]
    [Alias("employee")]
    public class Employee : DropDownBaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
