using EBonik.Data.Entities;
using EBonik.Data.Entities.UI;
using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.Entities;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Entities.PromotionArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.HistoryArea;
using IqraService.Search;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.UI
{
    public class PromotionService : IqraCommerce.Services.AppBaseService<Promotion>
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
                    name = "promotion." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Rank] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, PromotionQuery.Get());
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
                                     "Upload/Change Showcase image",
                                     "Image Upload",
                                     activityId,
                                     userId);
            SaveChange();


            return new Response(200, null, false, "successed");
        }
    }

    public class PromotionQuery
    {
        public static string Get()
        {
            return @" [Id]
                  ,[CreatedAt]
                  ,[CreatedBy]
                  ,[UpdatedAt]
                  ,[UpdatedBy]
                  ,[IsDeleted]
                  ,[Remarks]
                  ,[ActivityId]
                  ,[Name]
                  ,[PromotionType]
                  ,[Headline]
                  ,[Content]
                  ,[StartingAt]
                  ,[EndingAt]
                  ,ISNULL('/images/promotion/icon/' + [ImageURL], '') [ImageURL]
                  ,[IsVisible]
                  ,[Rank]
              FROM [dbo].[Promotion] promotion";
        }
    }
}
