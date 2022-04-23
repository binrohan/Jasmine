using EBonik.Data.Entities.UI;
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

namespace IqraCommerce.Services.UI
{
    public class DisplayProductService : IqraCommerce.Services.AppBaseService<DisplayProduct>
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
                    name = "displayproduct." + name;
                    break;
            }
            return base.GetName(name);
        }

        public async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetProductsByDisplay(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, DisplayProductQuery.GetProductsByCategory());
            }
        }
    }

    public class DisplayProductQuery
    {
        public static string GetProductsByCategory()
        {
            return @"[displayproduct].[Id],
		            [displayproduct].ProductId,
		            [displayproduct].DisplayId,
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
	            INNER JOIN DisplayProduct displayproduct ON product.Id = DisplayProduct.ProductId
	            LEFT JOIN Brand brand ON brand.Id = product.BrandId
	            LEFT JOIN Unit unit ON unit.Id = product.UnitId";
        }

    }
}
