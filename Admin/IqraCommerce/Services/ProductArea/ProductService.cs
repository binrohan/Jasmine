using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.DTOs.Product;
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
                case "unitname":
                    name = "unit.[Name]";
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

        public Response MarkAsHighlighted(Guid productId)
        {
            var productFromRepo = Entity.Find(productId);

            if(productFromRepo is null) return new Response(-404, null, true, "Product not found");

            if(productFromRepo.IsHighlighted) return new Response(-403, null, true, "Product already marked as highlighted");

            productFromRepo.IsHighlighted = true;

            SaveChange();

            return new Response(200, null, false, "successed");
        }

        public Response UnmarkAsHighlighted(Guid productId)
        {
            var productFromRepo = Entity.Find(productId);

            if (productFromRepo is null) return new Response(-404, null, true, "Product not found");

            productFromRepo.IsHighlighted = false;

            SaveChange();

            return new Response(200, null, false, "successed");
        }


        

        public Response UploadHighlightedImage(string fileName, Guid id, Guid userId, Guid activityId)
        {
            var productFromRepo = Entity.Find(id);

            var temp = productFromRepo;

            productFromRepo.HighlightedImageURL = fileName;
            productFromRepo.UpdatedAt = DateTime.Now;
            productFromRepo.UpdatedBy = userId;

            ChangeHistoryService.Set(this,
                                     id,
                                     new { FileName = fileName, UserId = userId, ProductId = id },
                                     temp,
                                     productFromRepo,
                                     "Upload/Change product Hightlighted image",
                                     "Hightlighted image change",
                                     activityId,
                                     userId);
            SaveChange();


            return new Response(200, null, false, "successed");
        }

        public Response UploadImages(IList<string> filenames, Guid id, Guid userId, Guid activityId)
        {
            foreach (var filename in filenames)
            {
                ProductImage productImage = new ProductImage
                {
                    ActivityId = activityId,
                    CreatedBy = userId,
                    CreatedAt = DateTime.Now,
                    ImageURL = filename,
                    ProductId = id,
                };


                GetEntity<ProductImage>().Add(productImage);
            }
            
            SaveChange();

            return new Response(200, null, false, "successed");
        }

        public Response Description(Guid productId)
        {
            var productFromRepo = Entity.Find(productId);

            var productToReturn = new ProductDescriptionDto
            {
                Id = productFromRepo.Id,
                Name = productFromRepo.Name,
                CurrentPrice = productFromRepo.CurrentPrice,
                Description = productFromRepo.Description,
            };

            return new Response(200, productToReturn, false, "Successed");
        }

        public Response SaveDescription(SaveDescriptionDto product)
        {
            var productFromRepo = Entity.Find(product.Id);

            productFromRepo.Description = product.Description;

            SaveChange();

            return new Response(200, productFromRepo, false, "Successed");
        }

        public Response Images(Guid productId)
        {
            var images = GetEntity<ProductImage>().Where(pi => pi.ProductId == productId && !pi.IsDeleted).ToList();

            return new Response(200, images, false, "Successed");
        }

        public Response MarkImageAsPrimary(Guid productId, Guid imageId)
        {
            var images = GetEntity<ProductImage>().Where(pi => pi.ProductId == productId && !pi.IsDeleted).ToList();

            foreach (var image in images)
            {
                if (image.Id == imageId)
                    image.IsPrimary = true;
                else
                    image.IsPrimary = false;
            }

            SaveChange();

            return new Response(200, images, false, "Successed");
        }

        public Response Remove(Guid productId, Guid imageId)
        {
            var images = GetEntity<ProductImage>().Where(pi => pi.ProductId == productId && !pi.IsDeleted).ToList();

            foreach (var image in images)
            {
                if (image.Id == imageId)
                    image.IsDeleted = true;
            }

            SaveChange();

            return new Response(200, images.Where(i => !i.IsDeleted), false, "Successed");
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
              ,product.[SearchQuery]
              ,product.[UnitId]
              ,product.[IsHighlighted]
              ,ISNULL('/images/products/highlights/icon/' + product.[HighlightedImageURL], '') [HighlightedImageURL]
	          ,ISNULL(unit.Name, '' ) UnitName
              FROM [dbo].[Product] product
              LEFT JOIN Unit unit ON unit.Id = product.UnitId";
        }

        public static string GetImages()
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
                  ,[ProductId]
                  ,[ImageURL]
                  ,[IsPrimary]
                  ,[IconURL]
                  ,[MimeType]
                  ,[ReferenceId]
                  ,[Size]
              FROM [dbo].[ProductImage]";
        }
    }
}
