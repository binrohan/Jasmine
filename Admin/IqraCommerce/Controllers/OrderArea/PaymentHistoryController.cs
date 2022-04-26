using System;
using System.Collections.Generic;
using IqraCommerce.Entities.OrderArea;
using IqraCommerce.Models.OrderArea;
using IqraCommerce.Services.PaymentHistoryArea;

namespace IqraCommerce.Controllers.MiscellaneousArea
{
    public class PaymentHistoryController : AppDropDownController<PaymentHistory, PaymentHistoryModel>
    {
        PaymentHistoryService ___service;
        public PaymentHistoryController()
        {
            service = __service = ___service = new PaymentHistoryService();
        }
    }
}
