using IqraBase.Service;
using IqraCommerce.Entities.OrderArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.OrderArea
{
    public class ShippingAddressService : IqraCommerce.Services.AppBaseService<ShippingAddress>
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
                    name = "[shippingaddress]." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[TypeOfAddress] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ShippingAddressQuery.Get());
            }
        }
        public async Task<ResponseList<Dictionary<string, object>>> GetByOrderId(Guid Id)
        {
            using (var db = new DBService(this))
            {
                return await db.FirstOrDefault(ShippingAddressQuery.Details + Id + "'");
            }
        }
    }

    public class ShippingAddressQuery
    {
        public static string Get()
        {
            return @"shippingaddress.[Id]
      ,shippingaddress.[CreatedAt]
      ,shippingaddress.[CreatedBy]
      ,shippingaddress.[UpdatedAt]
      ,shippingaddress.[UpdatedBy]
      ,shippingaddress.[IsDeleted]
      ,ISNULL(shippingaddress.[Remarks], ' ') [Remarks]
      ,shippingaddress.[ActivityId]
      ,ISNULL(shippingaddress.[Name], ' ') [Name]
      ,shippingaddress.[OrderId]
      ,shippingaddress.[RefCustomerId]
      ,ISNULL(shippingaddress.[Phone], ' ') [Phone]
      ,ISNULL(shippingaddress.[Email], ' ') [Email]
      ,shippingaddress.[TypeOfAddress]
      ,shippingaddress.[RefAddressId]
      ,shippingaddress.[ProvinceId]
      ,shippingaddress.[DistrictId]
      ,shippingaddress.[UpazilaId]
	  ,province.Name [ProvinceName]
	  ,district.Name [DistrictName]
	  ,upazila.Name [Area]
	  ,ISNULL([order].ShippingCharge, 0) [ShippingCharge]
	  ,district.ShippingCharge [OriginalShippingCharge]
  FROM [dbo].[ShippingAddress] shippingaddress
	LEFT JOIN [dbo].[Province] province ON province.Id = shippingaddress.ProvinceId
	LEFT JOIN [dbo].District district ON district.Id = shippingaddress.DistrictId
	LEFT JOIN [dbo].Upazila upazila ON upazila.Id = shippingaddress.UpazilaId
	LEFT JOIN [dbo].[Order] [order] ON [order].Id = shippingaddress.OrderId";
        }

        public static string Details { get { return @"select " + Get() + " Where shippingaddress.OrderId = '"; } }
    }
}
