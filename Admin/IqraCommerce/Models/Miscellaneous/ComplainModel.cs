using IqraBase.Data;
using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.ContactArea
{
    public class ComplainModel : DropDownBaseModel
    {
        public ComplainType ComplainType { get; set; }
        public string Message { get; set; }
        public ComplainStatus ComplainStatus { get; set; }
        public string Remarks { get; set; }

    }
}
