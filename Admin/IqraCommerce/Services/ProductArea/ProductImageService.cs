using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.ProductArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.ProductArea
{
    public class ProductImageService : IqraCommerce.Services.AppBaseService<ProductImage>
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
                    name = "productimage." + name;
                    break;
            }
            return base.GetName(name);
        }

        public async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetCategoriesByProduct(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ProductCategoryQuery.GetCategoriesByProduct());
            }
        }

        public ResponseJson UploadImage(ProductImageModel model,Guid userId)
        {
            return OnCreate(model, userId, true);
        }
        public ResponseJson SaveImage(ProductImageModel model, Guid userId)
        {
            return CallBack((response)=> {
                var images = Entity.Where(i => i.ReferenceId == model.ReferenceId).ToList();
                foreach(var image in images)
                {
                    image.ProductId = model.ProductId;
                    if (image.Id == model.PrimaryId)
                    {
                        image.IsPrimary = true;
                    }
                }

            });
        }
    }

    public class ProductImageQuery
    {
        public static string GetCategoriesByProduct()
        {
            return @"[ProductCategory].[Id]
                  ,[Category].[Name]
                  ,[Category].[Hierarchy],
                    [ProductCategory].ProductId,
					[ProductCategory].CategoryId
                FROM [dbo].[Category] category
                INNER JOIN ProductCategory productcategory ON [Category].Id = productcategory.CategoryId";
        }

        public static string GetProductsByCategory()
        {
            return @"[ProductCategory].[Id],
		            [ProductCategory].ProductId,
		            [ProductCategory].CategoryId,
		            product.Name,
		            product.CurrentPrice,
		            product.OriginalPrice,
		            product.DiscountedPrice,
		            product.DiscountedPercentage,
		            product.StockUnit,
		            product.PackSize,
		            product.UnitId,
		            unit.Name [UnitName]
	            FROM [dbo].[Product] product
	            INNER JOIN ProductCategory productcategory ON product.Id = productcategory.ProductId
	            LEFT JOIN Unit unit ON unit.Id = product.UnitId";
        }

    }
}
