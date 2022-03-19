﻿using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.Entities.ProductArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.ProductArea
{
    public class BrandService : IqraCommerce.Services.AppBaseService<Brand>
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
                    name = "brand." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, BrandQuery.Get());
            }
        }
    }

    public class BrandQuery
    {
        public static string Get()
        {
            return @"[Id]
                      ,[CreatedAt]
                      ,[CreatedBy]
                      ,[UpdatedAt]
                      ,[UpdatedBy]
                      ,[IsDeleted]
                      ,[Remarks]
                      ,[ActivityId]
                      ,[Name]
                      ,[Description]
                      ,[IsVisible]
                  FROM [dbo].[Brand] brand";
        }
    }
}
