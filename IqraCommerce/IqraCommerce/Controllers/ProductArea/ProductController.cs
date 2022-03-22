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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.ProductArea
{
    public class ProductController : AppDropDownController<Product, ProductModel>
    {
        ProductService ___service;
        private readonly IConfiguration _config;
        public ProductController(IConfiguration config)
        {
            _config = config;
            service = __service = ___service = new ProductService();
        }

        public ActionResult UploadImage([FromForm] ImageUploadDto imageUpload)
        {
            ImageManager imageManager = new ImageManager(_config);

            var fileName = imageManager.Store(imageUpload.Img, "Product");

            return Json(___service.UploadImage(fileName, imageUpload.Id, Guid.Empty, imageUpload.ActivityId));
        }
    }
}
