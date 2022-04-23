using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.ProductArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.ProductArea
{
    public class ProductImageController : AppDropDownController<ProductImage, ProductImageModel>
    {
        ProductImageService ___service;
        private readonly IConfiguration _config;
        public ProductImageController(IConfiguration config)
        {
            service = __service = ___service = new ProductImageService();
            _config = config;
        }

        public override ActionResult Index()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public ActionResult UploadHighlightedImage([FromForm] ImageUploadDto imageUpload)
        {
            ImageManager imageManager = new ImageManager(_config);

            var fileName = imageManager.Store(imageUpload.Img, "Product");
            var model = new ProductImageModel() { 
                ActivityId = imageUpload.ActivityId,
                ImageURL= fileName,
                Name= imageUpload.Img.FileName,
                IconURL = fileName,
                MimeType= imageUpload.Img.ContentType,
                ReferenceId = imageUpload.ReferenceId,
                Size = imageUpload.Img.Length
            };
            return Json(___service.UploadImage(model, Guid.Empty));
        }
        public ActionResult SaveImage([FromForm] ProductImageModel model)
        {

            return Json(___service.UploadImage(model, Guid.Empty));
        }
        public async Task<JsonResult> GetCategoriesByProduct([FromBody] Page page)
        {
            return Json(await ___service.GetCategoriesByProduct(page));
        }

        public override JsonResult Remove([FromForm] DeleteDto delete)
        {
            ___service.Remove(delete, Guid.Empty);

            return Json(new { });
        }
    }
}
