using System;
using System.Collections.Generic;

namespace IqraCommerce.API.Entities
{
    public partial class PaymentLog
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public Guid ActivityId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid PaymentId { get; set; }
        public double Amount { get; set; }
        public string TranId { get; set; }
        public string TranDate { get; set; }
        public string Status { get; set; }
        public string ValId { get; set; }
        public double? StoreAmount { get; set; }
        public string Currency { get; set; }
        public string BankTranId { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public string CardIssuer { get; set; }
        public string CardBrand { get; set; }
        public string CardIssuerCountry { get; set; }
        public string CardIssuerCountryCode { get; set; }
        public string CurrencyType { get; set; }
        public double? CurrencyAmount { get; set; }
        public double? CurrencyRate { get; set; }
        public string RiskTitle { get; set; }
        public string RiskLevel { get; set; }
        public string Apiconnect { get; set; }
        public DateTime ValidatedOn { get; set; }
        public string GwVersion { get; set; }
        public string PaymentType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
