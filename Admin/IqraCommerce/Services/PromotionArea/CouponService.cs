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
    public class CouponService : IqraCommerce.Services.AppBaseService<Coupon>
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
                    name = "coupon." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, CouponQuery.Get());
            }
        }
    }

    public class CouponQuery
    {
        public static string Get()
        {
            return @"[coupon].[Id]
                  ,[coupon].[CreatedAt]
                  ,[coupon].[CreatedBy]
                  ,[coupon].[UpdatedAt]
                  ,[coupon].[UpdatedBy]
                  ,[coupon].[IsDeleted]
                  ,ISNULL([coupon].[Remarks], '') [Remarks]
                  ,[coupon].[ActivityId]
                  ,ISNULL([coupon].[Name], '') [Name]
                  ,ISNULL([coupon].[Code], '') [Code]
                  ,[coupon].[StartingAt]
                  ,[coupon].[EndingAt]
                  ,[coupon].[IsPublished]
                  ,[coupon].[IsLimited]
                  ,[coupon].[MinOrderValue]
                  ,[coupon].[Count]
                  ,[coupon].[Discount]
                  ,[coupon].[MaxDiscount]
                  ,[coupon].[MinDiscount]
                  ,[coupon].[Redeemed]
              FROM [dbo].[Coupon] [coupon]";
        }
    }
}
