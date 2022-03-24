﻿using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.Entities;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.HistoryArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.ProductArea
{
    public class ProductService : IqraCommerce.Services.AppBaseService<Product>
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
                    name = "product." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ProductQuery.Get());
            }
        }


        public Response UploadImage(string fileName, Guid id, Guid userId, Guid activityId)
        {
            var productFromRepo = Entity.Find(id);

            var temp = productFromRepo;

            productFromRepo.ImageURL = fileName;
            productFromRepo.UpdatedAt = DateTime.Now;
            productFromRepo.UpdatedBy = userId;

            ChangeHistoryService.Set(this,
                                     id,
                                     new { FileName = fileName, UserId = userId, ProductId = id },
                                     temp,
                                     productFromRepo,
                                     "Upload/Change product image",
                                     "Image change",
                                     activityId,
                                     userId);
            SaveChange();


            return new Response(200, null, false, "successed");
        }
    }

    public class ProductQuery
    {
        public static string Get()
        {
            return @"product.[Id]
      ,product.[CreatedAt]
      ,product.[CreatedBy]
      ,product.[UpdatedAt]
      ,product.[UpdatedBy]
      ,product.[IsDeleted]
      ,product.[Remarks]
      ,product.[ActivityId]
      ,product.[Name]
      ,product.[DisplayName]
      ,product.[Excerpt]
      ,product.[PackSize]
      ,'/Images/Product/Icon/'+product.[ImageURL] [ImageURL]
      ,product.[CurrentPrice]
      ,product.[OriginalPrice]
      ,product.[DiscountedPrice]
      ,product.[DiscountedPercentage]
      ,product.[TradePrice]
      ,product.[SoldTradePrice]
      ,product.[Vat]
      ,product.[IsVatFixedType]
      ,product.[SoldPrice]
      ,product.[Profit]
      ,product.[StockUnit]
      ,product.[SoldUnit]
      ,product.[IsVisible]
      ,product.[IsInHomePage]
      ,product.[Rank]
      ,product.[Rating]
      ,product.[RatingCount]
      ,product.[BrandId]
      ,product.[IsUpComming]
      ,product.[SearchQuery]
      ,product.[UnitId]
      ,brand.Name BrandName
	  ,unit.Name UnitName
      FROM [dbo].[Product] product
      LEFT JOIN Brand brand ON brand.Id = product.BrandId
      LEFT JOIN Unit unit ON unit.Id = product.UnitId";
        }
    }
}
