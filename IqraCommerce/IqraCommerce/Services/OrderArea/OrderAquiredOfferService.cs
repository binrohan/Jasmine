using IqraBase.Service;
using IqraCommerce.Entities.OrderArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.OrderArea
{
    public class OrderAquiredOfferService : IqraCommerce.Services.AppBaseService<OrderAquiredOffer>
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
                    name = "[orderaquiredoffer]." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, OrderAquiredOfferQuery.Get());
            }
        }
    }

    public class OrderAquiredOfferQuery
    {
        public static string Get()
        {
            return @"[orderaquiredoffer].[Id]
                  ,[orderaquiredoffer].[CreatedAt]
                  ,[orderaquiredoffer].[CreatedBy]
                  ,[orderaquiredoffer].[UpdatedAt]
                  ,[orderaquiredoffer].[UpdatedBy]
                  ,[orderaquiredoffer].[IsDeleted]
                  ,ISNULL([orderaquiredoffer].[Remarks], '') [Remarks]
                  ,[orderaquiredoffer].[ActivityId]
                  ,ISNULL([orderaquiredoffer].[Name], '') [Name]
                  ,[orderaquiredoffer].[RefOfferId]
                  ,[orderaquiredoffer].[TypeOfOffer]
                  ,ISNULL([orderaquiredoffer].[Description], '') [Description]
                  ,[orderaquiredoffer].[Discount]
                  ,[orderaquiredoffer].[IsRedeemed]
                  ,[orderaquiredoffer].[OrderId]
              FROM [dbo].[OrderAquiredOffer] [orderaquiredoffer]";
        }
    }
}
