using EBonik.Data.Entities.UI;
using EBonik.Data.Models.UI;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.ProductArea;
using IqraCommerce.Services.UI;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.UI
{
    public class DisplayProductController : AppDropDownController<DisplayProduct, DisplayProductModel>
    {
        DisplayProductService ___service;
        public DisplayProductController()
        {
            service = __service = ___service = new DisplayProductService();
        }

        public override ActionResult Index()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public async Task<JsonResult> GetProductsByDisplay([FromBody] Page page)
        {
            return Json(await ___service.GetProductsByDisplay(page));
        }

        public override JsonResult Remove([FromForm] DeleteDto delete)
        {
            ___service.Remove(delete, Guid.Empty);

            return Json(new { });
        }
    }
}
