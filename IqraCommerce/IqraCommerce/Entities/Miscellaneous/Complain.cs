using IqraBase.Data;
using IqraBase.Data.Entities;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ContactArea
{
    [Table("Complain")]
    [Alias("complain")]
    public class Complain : DropDownBaseEntity
    {
        public ComplainType ComplainType { get; set; }
        public string Message { get; set; }
        public ComplainStatus ComplainStatus { get; set; }
    }
}
