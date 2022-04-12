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
    public class UpazilaService : IqraCommerce.Services.AppBaseService<Upazila>
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
                    name = "upazila." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, UpazilaQuery.Get());
            }
        }

        public override ResponseJson OnCreate(AppBaseModel model, Guid userId, bool isValid)
        {
            var recordToCreate = (UpazilaModel)model;

            var districtFromDb = GetEntity<District>().Find(recordToCreate.DistrictId);

            recordToCreate.ProvinceId = districtFromDb is null ? Guid.Empty : districtFromDb.ProvinceId;

            return base.OnCreate(recordToCreate, userId, isValid);
        }

        public override ResponseJson Update(AppBaseModel model, Guid userId)
        {
            var recordToUpdate = (UpazilaModel)model;

            var districtFromDb = GetEntity<District>().Find(recordToUpdate.DistrictId);

            recordToUpdate.ProvinceId = districtFromDb.ProvinceId;

            return base.Update(recordToUpdate, userId);
        }
    }

    public class UpazilaQuery
    {
        public static string Get()
        {
            return @"upazila.[Id]
                  ,upazila.[CreatedAt]
                  ,upazila.[CreatedBy]
                  ,upazila.[UpdatedAt]
                  ,upazila.[UpdatedBy]
                  ,upazila.[IsDeleted]
                  ,ISNULL(upazila.[Remarks], '') [Remarks]
                  ,upazila.[ActivityId]
                  ,ISNULL(upazila.[Name], '') [Name]
                  ,upazila.[UpazilaId]
                  ,upazila.[ProvinceId]
	              ,ISNULL(province.[Name], '') [Province]
                  ,upazila.[DistrictId]
	              ,ISNULL(district.[Name], '') [District]
                  ,upazila.[XMax]
                  ,upazila.[XMin]
                  ,upazila.[YMax]
                  ,upazila.[YMin]
                  ,upazila.[IsVisible]
              FROM [dbo].[Upazila] upazila
              LEFT JOIN [dbo].[District] district ON upazila.DistrictId = district.Id
              LEFT JOIN [dbo].[Province] province ON upazila.ProvinceId = province.Id";
        }
    }
}
