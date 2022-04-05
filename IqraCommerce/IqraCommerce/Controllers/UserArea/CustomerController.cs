using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using EBonik.Data.Models.UI;
using EBonik.Data.Models.UserArea;
using IqraCommerce.DTOs;
using IqraCommerce.Helpers;
using IqraCommerce.Services.UI;
using IqraCommerce.Services.UserArea;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace IqraCommerce.Controllers.UIArea
{
    public class CustomerController : AppDropDownController<Customer, CustomerModel>
    {
        CustomerService ___service;
        private readonly IConfiguration _config;
        public CustomerController(IConfiguration config)
        {
            _config = config;
            service = __service = ___service = new CustomerService();
        }
    }
}
