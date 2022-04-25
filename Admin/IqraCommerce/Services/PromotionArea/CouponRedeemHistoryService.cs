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
    public class CouponRedeemHistoryService : IqraCommerce.Services.AppBaseService<CouponRedeemHistory>
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
                    name = "couponredeemhistory." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, CouponRedeemHistoryQuery.Get());
            }
        }
    }

    public class CouponRedeemHistoryQuery
    {
        public static string Get()
        {
            return @"[couponredeemhistory].[Id]
                  ,[couponredeemhistory].[CreatedAt]
                  ,[couponredeemhistory].[CreatedBy]
                  ,[couponredeemhistory].[UpdatedAt]
                  ,[couponredeemhistory].[UpdatedBy]
                  ,[couponredeemhistory].[IsDeleted]
                  ,ISNULL([couponredeemhistory].[Remarks], '') [Remarks]
                  ,[couponredeemhistory].[ActivityId]
                  ,ISNULL([couponredeemhistory].[Name], '') [Name]
                  ,[couponredeemhistory].[CouponId]
	              ,[coupon].Code [Code]
	              ,[coupon].Remarks [CouponRemarks]
	              ,[coupon].Discount [CouponDiscount]
                  ,[couponredeemhistory].[CustomerId]
	              ,[customer].Phone [CustomerPhone]
	              ,ISNULL([customer].Name, '') [CustomerName]
                  ,[couponredeemhistory].[Value]
	              ,[order].OrderNumber [OrderNumber]
	              ,[order].OrderStatus [OrderStatus]
	              ,[order].OrderValue [OrderValue]
              FROM [dbo].[CouponRedeemHistory] [couponredeemhistory]
              LEFT JOIN [dbo].[Coupon] [coupon] ON [coupon].Id = [couponredeemhistory].CouponId
              LEFT JOIN [dbo].[Customer] [customer] ON [customer].Id = [couponredeemhistory].CustomerId
              LEFT JOIN [dbo].[Order] [order] ON [order].Id = [couponredeemhistory].OrderId";
        }
    }
}
