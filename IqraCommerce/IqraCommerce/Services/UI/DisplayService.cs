using EBonik.Data.Entities;
using EBonik.Data.Entities.UI;
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

namespace IqraCommerce.Services.UI
{
    public class DisplayService : IqraCommerce.Services.AppBaseService<Display>
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
                    name = "display." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Rank] asc";
            using (var db = new DBService(this))
            {
                var data = await db.GetPages(page, DisplayQuery.Get());
                return data;
            }
        }
    }

    public class DisplayQuery
    {
        public static string Get()
        {
            return @"display.[Id]
                  ,display.[CreatedAt]
                  ,display.[CreatedBy]
                  ,display.[UpdatedAt]
                  ,display.[UpdatedBy]
                  ,display.[IsDeleted]
                  ,ISNULL(display.[Remarks], '') [Remarks]
                  ,display.[ActivityId]
                  ,display.[Name]
                  ,display.[Rank]
                  ,display.[IsVisible]
              FROM [dbo].[Display] display";
        }
    }
}
