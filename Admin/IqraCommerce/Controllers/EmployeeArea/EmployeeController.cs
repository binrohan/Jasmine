using EBonik.Data.Entities.EmployeeArea;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using EBonik.Data.Models.UI;
using EBonik.Data.Models.UserArea;
using IqraCommerce.DTOs;
using IqraCommerce.Helpers;
using IqraCommerce.Models.EmployeeArea;
using IqraCommerce.Services.EmployeeArea;
using IqraCommerce.Services.UI;
using IqraCommerce.Services.UserArea;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace IqraCommerce.Controllers.EmployeeArea
{
    /// <summary>
    ///  /Employee/Login
    /// </summary>
    public class EmployeeController : AppDropDownController<Employee, EmployeeModel>
    {
        EmployeeService ___service;
        public EmployeeController()
        {
            service = __service = ___service = new EmployeeService();
        }
    }
}
