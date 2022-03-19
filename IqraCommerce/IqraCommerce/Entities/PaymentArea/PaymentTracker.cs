using IqraBase.Data;
using IqraBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.PaymentArea
{

    [Table("PaymentTracker")]
    [Alias("pmntlg")]
    public class PaymentTracker
    {
        public PaymentTracker() {

        }
        public PaymentTracker(Guid orderId)
        {
            OrderId = orderId;
        }
        public PaymentTracker(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid LogId { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
        public string Remarks { get; set; }
        //AppBaseService<T> where T : AppBaseEntity
        public static PaymentTracker Add(DbSet<PaymentTracker> service, Guid orderId, Guid customerId, string status, string remarks="")
        {
            var entity = new PaymentTracker(orderId, customerId) {
                Status = status,
                Remarks = remarks
            };
            service.Add(entity);
            return entity;
        }
        public static PaymentTracker Add(DbSet<PaymentTracker> service, Guid orderId, string status, string remarks = "")
        {
            return Add(service, orderId, Guid.Empty, status, remarks);
        }
    }
}
