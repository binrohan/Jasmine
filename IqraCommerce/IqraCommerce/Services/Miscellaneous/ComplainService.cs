using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Models.ContactArea;
using IqraBase.Service;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.ContactArea
{
    public class ComplainService : IqraCommerce.Services.AppBaseService<Complain>
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
                    name = "complain." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ComplainQuery.Get());
            }
        }

        //public async Task<ResponseJson> ChangeStatus(ComplainModel model, Guid userId)
        //{
        //    return await CallbackAsync((response) =>
        //    {
        //        var contact = GetById(model.Id);
        //        if (contact != null)
        //        {
        //            contact.Remarks = model.Remarks;
        //            contact.Status = model.Status;
        //            contact.UpdatedAt = DateTime.Now;
        //            contact.UpdatedBy = userId;
        //            SaveChange();
        //        }
        //        else
        //        {
        //            response.IsError = true;
        //            response.Id = -4;
        //            response.Msg = "Contact not found.";
        //        }
        //    });
        //}

    }

    public class ComplainQuery
    {
        public static string Get()
        {
            return @"complain.[Id]
                  ,complain.[CreatedAt]
                  ,complain.[CreatedBy]
                  ,complain.[UpdatedAt]
                  ,complain.[UpdatedBy]
                  ,complain.[IsDeleted]
                  ,ISNULL(complain.[Remarks], '') [Remarks]
                  ,complain.[ActivityId]
                  ,ISNULL(complain.[Name], '') [Name]
                  ,complain.[ComplainType]
                  ,ISNULL(complain.[Message], '') [Message]
                  ,complain.[ComplainStatus]
              FROM [dbo].[Complain] complain";
        }
    }
}
