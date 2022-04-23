
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

namespace EBonik.Data.Models.UI
{
    public class DisplayProductModel : DropDownBaseModel
    {
        public Guid ProductId { get; set; }
        public Guid DisplayId { get; set; }
        public string Remarks { get; set; }
    }
}
