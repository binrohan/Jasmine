using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.ContactArea
{
    public class ContactModel : DropDownBaseModel
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Massege { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
