using EBonik.Data.Entities.UI;
using EBonik.Data.Models.UI;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.PromotionArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.PromotionArea;
using IqraCommerce.Services.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace IqraCommerce.Controllers.UIArea
{
    public class CashbackController : AppDropDownController<Cashback, CashbackModel>
    {
        CashbackService ___service;
        public CashbackController()
        {
            service = __service = ___service = new CashbackService();
        }
    }
}
