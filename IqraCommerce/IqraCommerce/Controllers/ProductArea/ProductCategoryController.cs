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
    public class ProductCategoryController : AppDropDownController<ProductCategory, ProductCategoryModel>
    {
        ProductCategoryService ___service;
        public ProductCategoryController()
        {
            service = __service = ___service = new ProductCategoryService();
        }

        public override ActionResult Index()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public async Task<JsonResult> GetProductCategory([FromBody] Page page)
        {
            return Json(await ___service.GetProductCategory(page));
        }

        public override JsonResult Remove([FromForm] DeleteDto delete)
        {
            ___service.Remove(delete, Guid.Empty);

            return Json(new { });
        }
    }
}
