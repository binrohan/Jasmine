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
    public class ProvinceService : IqraCommerce.Services.AppBaseService<Province>
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
                    name = "province." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ProvinceQuery.Get());
            }
        }
    }

    public class ProvinceQuery
    {
        public static string Get()
        {
            return @"province.[Id]
                  ,province.[CreatedAt]
                  ,province.[CreatedBy]
                  ,province.[UpdatedAt]
                  ,province.[UpdatedBy]
                  ,province.[IsDeleted]
                  ,ISNULL(province.[Remarks], '') [Remarks]
                  ,province.[ActivityId]
                  ,ISNULL(province.[Name], '') [Name]
                  ,province.[ProvinceId]
                  ,province.[AreaId]
                  ,province.[XMax]
                  ,province.[XMin]
                  ,province.[YMax]
                  ,province.[YMin]
                  ,province.[IsVisible]
              FROM [dbo].[Province] province";
        }
    }
}
