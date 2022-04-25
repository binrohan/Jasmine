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
    public class CashbackHistoryController : AppDropDownController<CashbackHistory, CashbackHistoryModel>
    {
        CashbackHistoryService ___service;
        public CashbackHistoryController()
        {
            service = __service = ___service = new CashbackHistoryService();
        }
    }
}
