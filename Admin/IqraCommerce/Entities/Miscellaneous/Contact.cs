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
    [Table("Contact")]
    [Alias("contact")]
    public class Contact : DropDownBaseEntity
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }
        public string Status { get; set; }

    }
}
