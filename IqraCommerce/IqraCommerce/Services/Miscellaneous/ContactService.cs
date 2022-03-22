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
    public class ContactService : IqraCommerce.Services.AppBaseService<Contact>
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
                    name = "cntct." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, ContactQuery.Get());
            }
        }

        public async Task<ResponseJson> ChangeStatus(ContactModel model, Guid userId)
        {
            return await CallbackAsync((response) =>
            {
                var contact = GetById(model.Id);
                if (contact != null)
                {
                    contact.Remarks = model.Remarks;
                    contact.Status = model.Status;
                    contact.UpdatedAt = DateTime.Now;
                    contact.UpdatedBy = userId;
                    SaveChange();
                }
                else
                {
                    response.IsError = true;
                    response.Id = -4;
                    response.Msg = "Contact not found.";
                }
            });
        }

    }

    public class ContactQuery
    {
        public static string Get()
        {
            return @"cntct.[Id]
                  ,cntct.[Name]
                  ,cntct.[CreatedAt]
                  ,cntct.[IsDeleted]
                  ,cntct.[Mobile]
                  ,cntct.[Email]
                  ,cntct.[Massege]
                  ,cntct.[ActivityId]
                  ,cntct.[Status]
                  ,cntct.[Remarks]
	              ,cstmr.[Name] [Customer]
                  FROM [dbo].[Contact] cntct
                  left join [dbo].[Customer] cstmr on cntct.[CreatedBy]=cstmr.Id";
        }
    }
}
