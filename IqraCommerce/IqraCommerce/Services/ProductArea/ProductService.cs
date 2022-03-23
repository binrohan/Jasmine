using EBonik.Data.Models.ContactArea;
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
            return @"[Id]
      ,[CreatedAt]
      ,[CreatedBy]
      ,[UpdatedAt]
      ,[UpdatedBy]
      ,[IsDeleted]
      ,[Remarks]
      ,[ActivityId]
      ,[Name]
      ,[DisplayName]
      ,[Excerpt]
      ,[PackSize]
      ,'/Images/Product/Icon/'+[ImageURL] [ImageURL]
      ,[CurrentPrice]
      ,[OriginalPrice]
      ,[DiscountedPrice]
      ,[DiscountedPercentage]
      ,[TradePrice]
      ,[SoldTradePrice]
      ,[Vat]
      ,[IsVatFixedType]
      ,[SoldPrice]
      ,[Profit]
      ,[StockUnit]
      ,[SoldUnit]
      ,[IsVisible]
      ,[IsInHomePage]
      ,[Rank]
      ,[Rating]
      ,[RatingCount]
      ,[BrandId]
      ,[IsUpComming]
      ,[SearchQuery]
      ,[UnitId]
  FROM [dbo].[Product] product";
        }
    }
}
