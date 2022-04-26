using EBonik.Data.Entities.UserArea;
using IqraBase.Service;
using IqraCommerce.Data;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.OrderArea;
using IqraCommerce.Entities.PromotionArea;
using IqraCommerce.Helpers;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.PaymentHistoryArea
{
    public class PaymentHistoryService : IqraCommerce.Services.AppBaseService<PaymentHistory>
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
                    name = "[paymenthistory]." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, PaymentHistoryQuery.Get());
            }
        }
    }


    public class PaymentHistoryQuery
    {
        public static string Get()
        {
            return @"[paymenthistory].[Id]
                  ,[paymenthistory].[CreatedAt]
                  ,[paymenthistory].[CreatedBy]
                  ,[paymenthistory].[UpdatedAt]
                  ,[paymenthistory].[UpdatedBy]
                  ,[paymenthistory].[IsDeleted]
                  ,[paymenthistory].[ActivityId]
                  ,[paymenthistory].[Name]
                  ,[paymenthistory].[Medium]
                  ,[paymenthistory].[Remarks]
                  ,[paymenthistory].[OrderId]
	              ,[order].[OrderNumber]
                  ,[paymenthistory].[CustomerId]
	              ,[customer].Phone [Phone]
                  ,[paymenthistory].[Reference]
                  ,[paymenthistory].[Amount]
              FROM [dbo].[PaymentHistory] [paymenthistory]
              LEFT JOIN [dbo].[Order] [order] ON [order].Id = [paymenthistory].[OrderId]
              LEFT JOIN [dbo].[Customer] [customer] ON [customer].Id = [paymenthistory].[CustomerId]";
        }
    }
}
