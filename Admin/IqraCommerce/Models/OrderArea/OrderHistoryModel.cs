using IqraBase.Data.Models;
using IqraCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Models.OrderArea
{
    public class OrderHistoryModel : DropDownBaseModel
    {
        public Guid OrderId { get; set; }
        public OrderAction TypeOfAction { get; set; }
        public string Remarks { get; set; }
    }
}
