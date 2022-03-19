using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Entities.ProductOrderArea
{
    [Table("OrderPrescription")]
    [Alias("odrprscptn")]
    public partial class OrderPrescription : AppBaseEntity
    {
        public OrderPrescription()
        {

        }
        public OrderPrescription(Guid userId) : base(userId)
        {

        }
        public Guid OrderId { get; set; }
        public Guid PrescriptionId { get; set; }
        public string Description { get; set; }
    }
}
