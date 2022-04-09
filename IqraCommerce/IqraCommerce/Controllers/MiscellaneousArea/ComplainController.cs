using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Models.ContactArea;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.ContactArea;
using IqraCommerce.Services.ProductArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.ProductArea
{
    public class ComplainController : AppDropDownController<Complain, ComplainModel>
    {
        ComplainService ___service;
        public ComplainController()
        {
            service = __service = ___service = new ComplainService();
        }
    }
}
