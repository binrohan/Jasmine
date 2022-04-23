using EBonik.Data.Entities.AddressArea;
using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Models.ContactArea;
using EBonik.Data.Models.LocationArea;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.ContactArea;
using IqraCommerce.Services.LocationArea;
using IqraCommerce.Services.ProductArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.LocationArea
{
    public class DistrictController : AppDropDownController<District, DistrictModel>
    {
        DistrictService ___service;
        public DistrictController()
        {
            service = __service = ___service = new DistrictService();
        }
    }
}
