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
    public class DisplayController : AppDropDownController<Display, DisplayModel>
    {
        DisplayService ___service;
        public DisplayController()
        {
            service = __service = ___service = new DisplayService();
        }
    }
}
