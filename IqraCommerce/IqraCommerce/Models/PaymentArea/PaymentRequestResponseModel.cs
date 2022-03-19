using System.Collections.Generic;

namespace EBonik.Data.Models.PaymentArea
{
    public class PaymentRequestResponseModel
    {
        public PaymentRequestResponseModel()
        {
            gw = new PaymentTypeModel();
            desc = new List<PaymentTypeDecModel>();
        }
        public string status { get; set; }
        public string failedreason { get; set; }
        public string sessionkey { get; set; }
        public PaymentTypeModel gw { get; set; }
        public string redirectGatewayURL { get; set; }
        public string redirectGatewayURLFailed { get; set; }
        public string GatewayPageURL { get; set; }
        public string storeBanner { get; set; }
        public string storeLogo { get; set; }
        public List<PaymentTypeDecModel> desc { get; set; }
    }
}
