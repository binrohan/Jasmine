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
    public class ProductImageController : AppDropDownController<ProductImage, ProductImageModel>
    {
        ProductImageService ___service;
        public ProductImageController()
        {
            service = __service = ___service = new ProductImageService();
        }

        public override ActionResult Index()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public async Task<JsonResult> GetCategoriesByProduct([FromBody] Page page)
        {
            return Json(await ___service.GetCategoriesByProduct(page));
        }

        public async Task<JsonResult> GetProductsByCategory([FromBody] Page page)
        {
            return Json(await ___service.GetProductsByCategory(page));
        }

        public override JsonResult Remove([FromForm] DeleteDto delete)
        {
            ___service.Remove(delete, Guid.Empty);

            return Json(new { });
        }
    }
}
