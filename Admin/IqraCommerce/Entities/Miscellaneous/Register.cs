using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ContactArea
{
    [Table("Register")]
    [Alias("register")]
    public class Register : DropDownBaseEntity
    {
        public string OTP { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsPassed { get; set; }
        public Guid CustomerId { get; set; }
    }
}
