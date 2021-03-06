using EBonik.Data.Entities;
using EBonik.Data.Entities.UI;
using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.Entities;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.HistoryArea;
using IqraService.Search;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IqraCommerce.Entities.PromotionArea;
using EBonik.Data.Entities.EmployeeArea;

namespace IqraCommerce.Services.EmployeeArea
{
    public class EmployeeService : IqraCommerce.Services.AppBaseService<Employee>
    {
        public override string GetName(string name)
        {
            switch (name.ToLower())
            {
                case "creator":
                    name = "ctr.Name";
                    break;
                case "updator":
                    name = "updtr.Name";
                    break;
                case "customer":
                    name = "cstmr.[Name]";
                    break;
                default:
                    name = "employee." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, EmployeeQuery.Get());
            }
        }
    }

    public class EmployeeQuery
    {
        public static string Get()
        {
            return @"cashback.[Id]
                  ,cashback.[CreatedAt]
                  ,cashback.[CreatedBy]
                  ,cashback.[UpdatedAt]
                  ,cashback.[UpdatedBy]
                  ,cashback.[IsDeleted]
                  ,ISNULL(cashback.[Remarks], '') [Remarks]
                  ,cashback.[ActivityId]
                  ,ISNULL(cashback.[Name], '') [Name]
                  ,cashback.[StartingAt]
                  ,cashback.[EndingAt]
                  ,cashback.[IsPublished]
                  ,cashback.[MinOrderValue]
                  ,cashback.[Amount]
              FROM [dbo].[Cashback] cashback";
        }
    }
}
