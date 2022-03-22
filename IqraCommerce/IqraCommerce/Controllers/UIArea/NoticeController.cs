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
    public class NoticeController : AppDropDownController<Notice, NoticeModel>
    {
        NoticeService ___service;
        public NoticeController()
        {
            service = __service = ___service = new NoticeService();
        }
    }
}
