using EBonik.Data.Entities.UI;
using EBonik.Data.Models.UI;
using IqraCommerce.DTOs;
using IqraCommerce.Helpers;
using IqraCommerce.Services.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace IqraCommerce.Controllers.ReportArea
{
    public class ReportController : Controller
    {
        public ActionResult Invoice()
        {
            return View();
        }
    }
}
