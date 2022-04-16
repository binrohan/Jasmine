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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.UI
{
    public class ShowcaseService : IqraCommerce.Services.AppBaseService<Showcase>
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
                    name = "showcase." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Rank] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ShowcaseQuery.Get());
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

    public class ShowcaseQuery
    {
        public static string Get()
        {
            return @"          showcase.[Id]
							  ,showcase.[CreatedAt]
							  ,showcase.[CreatedBy]
							  ,showcase.[UpdatedAt]
							  ,showcase.[UpdatedBy]
							  ,showcase.[IsDeleted]
							  ,ISNULL(showcase.[Remarks], '') [Remarks]
							  ,showcase.[ActivityId]
							  ,ISNULL(showcase.[Name], '') [Name]
							  ,showcase.[Rank]
							  ,showcase.[IsVisible]
							  ,ISNULL('/Images/Showcase/Icon/' + [ImageURL], '') [ImageURL]
						  FROM [dbo].[Showcase] showcase";
        }
    }
}
