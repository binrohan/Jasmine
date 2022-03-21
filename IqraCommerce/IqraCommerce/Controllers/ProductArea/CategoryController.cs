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
    public class CategoryController : AppDropDownController<Category, CategoryModel>
    {
        CategoryService ___service;
        public CategoryController()
        {
            service = __service = ___service = new CategoryService();
        }

        public override ActionResult Create([FromForm] CategoryModel recordToCreate)
        {
            return Json(___service.Create(recordToCreate, Guid.Empty));
        }

        public override ActionResult Edit([FromForm] CategoryModel recordToCreate)
        {
            return Json(___service.Update(recordToCreate, Guid.Empty));
        }

        public ActionResult GetExceptByProduct([FromBody] Page page, [FromRoute]Guid productId)
        {
            return Json(___service.GetExceptByProduct(page, productId));
        }
    }
}
