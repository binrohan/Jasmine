using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.OrderArea;
using IqraCommerce.Models.OrderArea;
using IqraCommerce.Services.OrderArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.Controllers.MiscellaneousArea
{
    public class OrderAquiredOfferController : AppDropDownController<OrderAquiredOffer, OrderAquiredOfferModel>
    {
        OrderAquiredOfferService ___service;
        public OrderAquiredOfferController()
        {
            service = __service = ___service = new OrderAquiredOfferService();
        }
    }
}
