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
    public class ShippingAddressController : AppDropDownController<ShippingAddress, ShippingAddressModel>
    {
        ShippingAddressService ___service;
        public ShippingAddressController()
        {
            service = __service = ___service = new ShippingAddressService();
        }

        public async Task<JsonResult> GetByOrderId([FromQuery]Guid id)
        {
            return Json(await ___service.GetByOrderId(id));
        }
    }
}
