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
    public class OrderController : AppDropDownController<Order, OrderModel>
    {
        OrderService ___service;
        public OrderController()
        {
            service = __service = ___service = new OrderService();
        }

        public override ActionResult Index()
        {
            if(IsLoggedId) return View();

            return View();

        }

        public async Task<IActionResult> ChangeStatus([FromForm]OrderStatusChangeDto order)
        {
            return Json(await ___service.ChangeStatus(order, Guid.Empty));
        }
    }
}
