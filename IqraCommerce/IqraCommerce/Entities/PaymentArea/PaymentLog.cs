using IqraBase.Data;
using IqraBase.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBonik.Data.Entities.PaymentArea
{
    [Table("PaymentLog")]
    [Alias("pmntlg")]
    public class PaymentLog:AppBaseEntity
    {
        public PaymentLog()
        {
            status = "Initiating";
            currency = "BDT";
        }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid PaymentId { get; set; }
        /// <summary>
        /// Payable Amount
        /// </summary>
        public double Amount { get; set; }
        public string tran_id { get; set; }
        public string tran_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        public string val_id { get; set; }
        public Nullable<double> store_amount { get; set; }
        public string currency { get; set; }
        public string bank_tran_id { get; set; }
        public string card_type { get; set; }
        public string card_no { get; set; }
        public string card_issuer { get; set; }
        public string card_brand { get; set; }
        public string card_issuer_country { get; set; }
        public string card_issuer_country_code { get; set; }
        public string currency_type { get; set; }
        public Nullable<double> currency_amount { get; set; }
        public Nullable<double> currency_rate { get; set; }
        public string risk_title { get; set; }
        public string risk_level { get; set; }
        public string APIConnect { get; set; }
        public DateTime validated_on { get; set; }
        public string gw_version { get; set; }
        public string PaymentType { get; set; }//Exam,HalfCourse,FullCourse
        /// <summary>
        /// Customer Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string Phone { get; set; }

    }
}
