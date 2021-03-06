using EBonik.Data.Entities;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
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

namespace IqraCommerce.Services.UserArea
{
    public class CustomerAddressService : IqraCommerce.Services.AppBaseService<CustomerAddress>
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
                    name = "customeraddress." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, CustomerAddressQuery.Get());
            }
        }
    }

    public class CustomerAddressQuery
    {
        public static string Get()
        {
            return @"
                        [Id]
                      ,[CreatedAt]
                      ,[CreatedBy]
                      ,[UpdatedAt]
                      ,[UpdatedBy]
                      ,[IsDeleted]
                      ,[Remarks]
                      ,[ActivityId]
                      ,[Name]
                      ,[CustomerId]
                      ,[Phone]
                      ,[Email]
                      ,[ProvinceId]
                      ,[DistrictId]
                      ,[UpazilaId]
                      ,[TypeOfAddress]
                      ,[IsPrimary]
                  FROM [dbo].[CustomerAddress] customeraddress";
        }
    }
}
