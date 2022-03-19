using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Models.ContactArea;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Services.ContactArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.Controllers.MiscellaneousArea
{
    public class ContactController : IqraDropDownController<Contact, ContactModel>
    {
        ContactService __service;
        public ContactController()
        {
            service = __service = new ContactService();
        }

        public override ActionResult Index()
        {
            if(IsLoggedId) return View();

            return View();

        }

        public override async Task<JsonResult> Get([FromBody]Page page)
        {
            return Json(await __service.Get(page));
        }

        public async Task<ActionResult> ChangeStatus([FromForm] ContactModel model)
        {
            var data = await __service.ChangeStatus(model, Guid.Empty);
            return Json(data);
        }

        public JsonResult Remove([FromBody]DeleteDto deleteDto)
        {
           __service.Remove(deleteDto, Guid.Empty);

            return Json(new { });
        }
    }
}
