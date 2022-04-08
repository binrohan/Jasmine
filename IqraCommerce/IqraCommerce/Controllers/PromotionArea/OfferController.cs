using EBonik.Data.Entities.UI;
using EBonik.Data.Models.UI;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.PromotionArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.PromotionArea;
using IqraCommerce.Services.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace IqraCommerce.Controllers.UIArea
{
    public class OfferController : AppDropDownController<Offer, OfferModel>
    {
        OfferService ___service;
        private readonly IConfiguration _config;
        public OfferController(IConfiguration config)
        {
            _config = config;
            service = __service = ___service = new OfferService();
        }

        public ActionResult UploadImage([FromForm] ImageUploadDto imageUpload)
        {
            ImageManager imageManager = new ImageManager(_config);

            var fileName = imageManager.Store(imageUpload.Img, "Offer");

            return Json(___service.UploadImage(fileName, imageUpload.Id, Guid.Empty, imageUpload.ActivityId));
        }
    }
}
