namespace EBonik.Data.Models.PaymentArea
{
    public class PaymentPostedModel
    {
        public string tran_id { get; set; }
        public string val_id { get; set; }
        public double amount { get; set; }
        public string card_type { get; set; }
        public double store_amount { get; set; }
        public string card_no { get; set; }
        public string bank_tran_id { get; set; }
        public string status { get; set; }
        public string tran_date { get; set; }
        public string currency { get; set; }
        public string card_issuer { get; set; }
        public string card_brand { get; set; }
        public string card_issuer_country { get; set; }
        public string card_issuer_country_code { get; set; }
        public string store_id { get; set; }
        public string verify_sign { get; set; }
        public string verify_key { get; set; }
        public string currency_type { get; set; }
        public double currency_amount { get; set; }
        public double currency_rate { get; set; }
        public string base_fair { get; set; }
        public string risk_level { get; set; }
        public string risk_title { get; set; }
    }
}
