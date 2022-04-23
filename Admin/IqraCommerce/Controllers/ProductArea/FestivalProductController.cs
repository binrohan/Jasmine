using IqraBase.Data;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.ProductArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.ProductArea
{
    public class FestivalProductController : AppDropDownController<FestivalProduct, FestivalProductModel>
    {
        FestivalProductService ___service;
        public FestivalProductController()
        {
            service = __service = ___service = new FestivalProductService();
            //var db = new AppDB();
        }

        public async Task<JsonResult> GetFestivalsByProduct([FromBody] Page page)
        {
            return Json(await ___service.GetFestivalsByProduct(page));
        }

        public async Task<JsonResult> GetProductsByFestival([FromBody] Page page)
        {
            return Json(await ___service.GetProductsByFestival(page));
        }

        public override JsonResult Remove([FromForm] DeleteDto delete)
        {
            ___service.Remove(delete, Guid.Empty);

            return Json(new { });
        }
    }
}
