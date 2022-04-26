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

namespace IqraCommerce.Services.UI
{
    public class CashbackHistoryService : IqraCommerce.Services.AppBaseService<CashbackHistory>
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
                    name = "cashbackhistory." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, CashbackHistoryQuery.Get());
            }
        }
    }

    public class CashbackHistoryQuery
    {
        public static string Get()
        {
            return @"[cashbackhistory].[Id]
                  ,[cashbackhistory].[CreatedAt]
                  ,[cashbackhistory].[CreatedBy]
                  ,[cashbackhistory].[UpdatedAt]
                  ,[cashbackhistory].[UpdatedBy]
                  ,[cashbackhistory].[IsDeleted]
                  ,[cashbackhistory].[ActivityId]

                  ,ISNULL([cashbackhistory].[Name], '') [Name]
                  ,[cashbackhistory].[CashbackId]

                  ,ISNULL([cashbackhistory].[Remarks], '') [Remarks]
	              
                  ,[cashbackhistory].[CustomerId]
	              ,[customer].Phone [CustomerPhone]
	              ,ISNULL([customer].Name, '') [CustomerName]
                  ,[cashbackhistory].Amount
	              ,[order].OrderNumber [OrderNumber]
	              ,[order].OrderStatus [OrderStatus]
	              ,[order].PayableAmount [PayableAmount]
				  
              FROM [dbo].[CashbackHistory] [cashbackhistory]
              LEFT JOIN [dbo].[Cashback] [cashback] ON [cashback].Id = [cashbackhistory].CashbackId
              LEFT JOIN [dbo].[Customer] [customer] ON [customer].Id = [cashbackhistory].CustomerId
              LEFT JOIN [dbo].[Order] [order] ON [order].Id = [cashbackhistory].OrderId";
        }
    }
}
