using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.RequestOrderArea
{
    public class RequestOrderItemModel
    {
        //public Guid OrderId { get; set; }
        public string Name { get; set; } // not use currently.
        public string Strength { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
        /// <summary>
        /// Position in the same order.
        /// </summary>
        public double Position { get; set; }
    }
}
