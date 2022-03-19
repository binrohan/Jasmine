using IqraBase.Data;
using IqraBase.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Models.ProductOrderArea
{
    [Table("OrderShipping")]
    [Alias("odrspng")]
    public partial class OrderShippingModel : DropDownBaseModel
    {
        public Guid ProductOrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public Guid ThanaId { get; set; }
        public Guid DistictId { get; set; }
        public string Remarks { get; set; }
    }
}
