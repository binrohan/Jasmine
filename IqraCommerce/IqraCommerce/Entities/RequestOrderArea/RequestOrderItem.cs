using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.RequestOrderArea
{
    [Table("RequestOrderItem")]
    [Alias("rqstordritm")]
    public class RequestOrderItem
    {
        public RequestOrderItem() {
            Id = Guid.NewGuid();
        }
        public RequestOrderItem(Guid orderId)
        {
            OrderId = orderId;
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
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
