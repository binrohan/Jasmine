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
    public class OrderProductController : AppDropDownController<OrderProduct, OrderProductModel>
    {
        OrderProductService ___service;
        public OrderProductController()
        {
            service = __service = ___service = new OrderProductService();
        }

        public override ActionResult Index()
        {
            if(IsLoggedId) return View();

            return View();

        }
    }
}
