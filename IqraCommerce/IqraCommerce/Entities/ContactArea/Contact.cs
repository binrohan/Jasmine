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
    [Alias("cntct")]
    public class Contact : DropDownBaseEntity
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }
        /// <summary>
        /// Device Activity
        /// </summary>
        public string Status { get; set; }

    }
}
