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
    public class BrandController : IqraDropDownController<Brand, BrandModel>
    {
        BrandService __service;
        public BrandController()
        {
            service = __service = new BrandService();
        }

        public override ActionResult Index()
        {
            if (IsLoggedId) return View();

            return View();
        }

        public override async Task<JsonResult> Get([FromBody] Page page)
        {
            return Json(await __service.Get(page));
        }

        public override ActionResult Create([FromForm]BrandModel brandToCreate)
        {
            return Json( __service.OnCreate(brandToCreate, Guid.Empty, true));
        }

        public override ActionResult Edit([FromForm] BrandModel recordToUpdate)
        {
            return Json(__service.Update(recordToUpdate, Guid.Empty));
        }

        public JsonResult Remove([FromBody] DeleteDto deleteDto)
        {
            __service.Remove(deleteDto, Guid.Empty);

            return Json(new { });
        }
    }
}
