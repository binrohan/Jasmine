using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Models.ContactArea;
using IqraBase.Web.Controllers;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.Miscellaneous;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Models.Miscellaneous;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.ContactArea;
using IqraCommerce.Services.Miscellaneous;
using IqraCommerce.Services.ProductArea;
using IqraService.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.MiscellaneousArea
{
    public class ReviewController : AppDropDownController<Review, ReviewModel>
    {
        ReviewService ___service;
        public ReviewController()
        {
            service = __service = ___service = new ReviewService();
        }
    }
}
