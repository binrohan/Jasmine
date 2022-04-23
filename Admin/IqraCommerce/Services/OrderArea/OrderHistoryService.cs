using IqraBase.Service;
using IqraCommerce.Entities.OrderArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.OrderArea
{
    public class OrderHistoryService : IqraCommerce.Services.AppBaseService<OrderHistory>
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
                    name = "[orderhistory]." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, OrderHistoryQuery.Get());
            }
        }
    }

    public class OrderHistoryQuery
    {
        public static string Get()
        {
            return @"orderhistory.[Id]
          ,orderhistory.[CreatedAt]
          ,orderhistory.[CreatedBy]
	      ,ISNULL(ISNULL(customer.Name, customer.Phone), ISNULL(customer.Name, '')) [Actor] --Employee name 
          ,orderhistory.[UpdatedAt]
          ,orderhistory.[UpdatedBy]
          ,orderhistory.[IsDeleted]
          ,ISNULL(orderhistory.[Remarks], '') [Remarks]
          ,orderhistory.[ActivityId]
          ,ISNULL(orderhistory.[Name], '') [Name]
          ,orderhistory.[OrderId]
          ,orderhistory.[TypeOfAction]
      FROM [dbo].[OrderHistory] orderhistory
      LEFT JOIN Customer customer ON customer.Id = orderhistory.[CreatedBy]";
        }
    }
}
