using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using EBonik.Data.Models.UI;
using EBonik.Data.Models.UserArea;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.NotificationArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.NotificationArea;
using IqraCommerce.Services.UI;
using IqraCommerce.Services.UserArea;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.NotificationArea
{
    public class NotificationController : AppDropDownController<Notification, NotificationModel>
    {
        NotificationService ___service;
        public NotificationController()
        {
            service = __service = ___service = new NotificationService();
        }
    }
}
