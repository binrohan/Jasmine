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
    public class ProductCategoryService : IqraCommerce.Services.AppBaseService<ProductCategory>
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
                    name = "productcategory." + name;
                    break;
            }
            return base.GetName(name);
        }

        public async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetProductCategory(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ProductCategoryQuery.GetProductCategory());
            }
        }
    }

    public class ProductCategoryQuery
    {
        public static string GetProductCategory()
        {
            return @"[ProductCategory].[Id]
                  ,[Category].[Name]
                  ,[Category].[Hierarchy],
                    [ProductCategory].ProductId,
					[ProductCategory].CategoryId
                FROM [dbo].[Category] category
                INNER JOIN ProductCategory productcategory ON [Category].Id = productcategory.CategoryId";
        }

    }
}
