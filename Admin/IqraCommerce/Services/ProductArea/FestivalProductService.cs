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
    public class FestivalProductService : IqraCommerce.Services.AppBaseService<FestivalProduct>
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
                case "productrank":
                    name = "product.[Rank]";
                    break;
                default:
                    name = "festivalproduct." + name;
                    break;
            }
            return base.GetName(name);
        }

        public async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetFestivalsByProduct(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, FestivalProductQuery.GetFestivalsByProduct());
            }
        }

        public async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetProductsByFestival(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, FestivalProductQuery.GetProductsByFestival());
            }
        }
    }

    public class FestivalProductQuery
    {
        public static string GetFestivalsByProduct()
        {
            return @"[ProductCategory].[Id]
                  ,[Category].[Name]
                  ,[Category].[Hierarchy],
                    [ProductCategory].ProductId,
					[ProductCategory].CategoryId
                FROM [dbo].[Category] category
                INNER JOIN ProductCategory productcategory ON [Category].Id = productcategory.CategoryId";
        }

        public static string GetProductsByFestival()
        {
            return @"festivalproduct.[Id],
		            festivalproduct.ProductId,
		            festivalproduct.FestivalId,
		            product.Name,
		            product.CurrentPrice,
		            product.OriginalPrice,
		            product.DiscountedPrice,
		            product.DiscountedPercentage,
		            product.StockUnit,
		            product.PackSize,
		            product.BrandId,
		            product.UnitId,
		            brand.Name [BrandName],
		            unit.Name [UnitName]
	            FROM [dbo].[Product] product
	            INNER JOIN FestivalProduct festivalproduct ON product.Id = festivalproduct.ProductId
	            LEFT JOIN Brand brand ON brand.Id = product.BrandId
	            LEFT JOIN Unit unit ON unit.Id = product.UnitId";
        }

    }
}
