using IqraBase.Service;
using IqraCommerce.Entities.OrderArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.OrderArea
{
    public class OrderProductService : IqraCommerce.Services.AppBaseService<OrderProduct>
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
                    name = "[orderproduct]." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, OrderProductQuery.Get());
            }
        }
    }

    public class OrderProductQuery
    {
        public static string Get()
        {
            return @"orderproduct.[Id]
                  ,orderproduct.[CreatedAt]
                  ,orderproduct.[CreatedBy]
                  ,orderproduct.[UpdatedAt]
                  ,orderproduct.[UpdatedBy]
                  ,orderproduct.[IsDeleted]
                  ,ISNULL(orderproduct.[Remarks], ' ') [Remarks]
                  ,orderproduct.[ActivityId]
                  ,ISNULL(orderproduct.[Name], ' ') [Name]
                  ,orderproduct.[OrderId]
                  ,orderproduct.[RefProductId]
                  ,ISNULL(orderproduct.[DisplayName], ' ') [DisplayName]
                  ,orderproduct.[PackSize]
                  ,orderproduct.[CurrentPrice]
                  ,orderproduct.[OriginalPrice]
                  ,orderproduct.[DiscountedPrice]
                  ,orderproduct.[DiscountedPercentage]
                  ,orderproduct.[Amount]
                  ,orderproduct.[Discount]
                  ,orderproduct.[Quantity]
	              ,ISNULL(unit.Name, '' ) UnitName
              FROM [dbo].[OrderProduct] orderproduct
              LEFT JOIN Product product ON orderproduct.RefProductId = product.Id
              LEFT JOIN Unit unit ON unit.Id = product.UnitId";
        }
    }
}
