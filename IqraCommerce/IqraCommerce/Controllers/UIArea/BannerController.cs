using EBonik.Data.Entities.UI;
using EBonik.Data.Models.UI;
using IqraCommerce.DTOs;
using IqraCommerce.Helpers;
using IqraCommerce.Services.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace IqraCommerce.Controllers.UIArea
{
    public class BannerController : AppDropDownController<Banner, BannerModel>
    {
        BannerService ___service;
        private readonly IConfiguration _config;
        public BannerController(IConfiguration config)
        {
            _config = config;
            service = __service = ___service = new BannerService();
        }

        public ActionResult Offer()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public ActionResult UploadImage([FromForm] ImageUploadDto imageUpload)
        {
            ImageManager imageManager = new ImageManager(_config);

            var fileName = imageManager.Store(imageUpload.Img, "Banner");

            return Json(___service.UploadImage(fileName, imageUpload.Id, Guid.Empty, imageUpload.ActivityId));
        }
    }
}
