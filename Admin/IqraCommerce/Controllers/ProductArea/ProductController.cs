using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.DTOs.Product;
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

        public ActionResult Highlighted()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public ActionResult Description()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public ActionResult Images()
        {
            return View();
        }

        public ActionResult UploadHighlightedImage([FromForm] ImageUploadDto imageUpload)
        {
            ImageManager imageManager = new ImageManager(_config);

            var fileName = imageManager.Store(imageUpload.Img, "ProductHighlight");

            return Json(___service.UploadHighlightedImage(fileName, imageUpload.Id, Guid.Empty, imageUpload.ActivityId));
        }

        public ActionResult MarkAsHighlighted([FromForm] ProductHighlightDto highlightDto)
        {
            return Json(___service.MarkAsHighlighted(highlightDto.ProductId));
        }

        public ActionResult UnmarkAsHighlighted([FromForm] ProductHighlightDto highlightDto)
        {
            return Json(___service.UnmarkAsHighlighted(highlightDto.ProductId));
        }
    
        public ActionResult ProductDescription([FromForm] IdDto product)
        {
            return Json(___service.Description(product.Id));
        }

        public ActionResult SaveDescription([FromForm] SaveDescriptionDto product)
        {
            return Json(___service.SaveDescription(product));
        }

        public ActionResult UploadImages([FromForm] ProductImageDto productImageDto)
        {
            ImageManager imageManager = new ImageManager(_config);

            var fileNames = imageManager.Store(productImageDto.Images, "Product");

            return Json(___service.UploadImages(fileNames, productImageDto.Id, Guid.Empty, productImageDto.ActivityId));
        }

        public ActionResult GetImages([FromForm] IdDto idDto)
        {
            return Json(___service.Images(idDto.Id));
        }

        public ActionResult MarkImageAsPrimary([FromForm] MarkImageAsPrimaryDto dto)
        {
            return Json(___service.MarkImageAsPrimary(dto.ProductId, dto.ImageId));
        }

        public ActionResult RemoveImage([FromForm] MarkImageAsPrimaryDto dto)
        {
            return Json(___service.Remove(dto.ProductId, dto.ImageId));
        }
    }
}
