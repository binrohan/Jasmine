using EBonik.Data.Entities.AddressArea;
using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Models.ContactArea;
using EBonik.Data.Models.LocationArea;
using IqraBase.Data.Models;
using IqraBase.Service;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.LocationArea
{
    public class DistrictService : IqraCommerce.Services.AppBaseService<District>
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
                    name = "district." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, DistrictQuery.Get());
            }
        }
    }

    public class DistrictQuery
    {
        public static string Get()
        {
            return @"district.[Id]
                  ,district.[CreatedAt]
                  ,district.[CreatedBy]
                  ,district.[UpdatedAt]
                  ,district.[UpdatedBy]
                  ,district.[IsDeleted]
                  ,ISNULL(district.[Remarks], ' ') [Remarks]
                  ,district.[ActivityId]
                  ,district.[ProvinceId]
                  ,ISNULL(province.[Name], ' ') [Province]
                  ,ISNULL(district.[Name], ' ') [Name]
                  ,district.[ShippingCharge]
                  ,district.[LowerBounderForMinShippingCharge]
                  ,district.[MinShippingCharge]
                  ,district.[XMax]
                  ,district.[XMin]
                  ,district.[YMax]
                  ,district.[YMin]
                  ,district.[IsVisible]
              FROM [dbo].[District] district
              LEFT JOIN [dbo].[Province] province ON district.ProvinceId = province.Id";
        }
    }
}
