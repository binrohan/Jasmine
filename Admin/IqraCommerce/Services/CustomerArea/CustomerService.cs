using EBonik.Data.Entities;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using EBonik.Data.Models.ContactArea;
using EBonik.Data.Models.UserArea;
using IqraBase.Data;
using IqraBase.Data.Models;
using IqraBase.Service;
using IqraCommerce.Data;
using IqraCommerce.DTOs.CustomerArea;
using IqraCommerce.Entities;
using IqraCommerce.Entities.NotificationArea;
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
    public class CustomerService : IqraCommerce.Services.AppBaseService<Customer>
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
                    name = "customer." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Name] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, CustomerQuery.Get());
            }
        }

        public override ResponseJson OnCreate(AppBaseModel model, Guid userId, bool isValid)
        {
            var appModel = (CustomerModel)model;

            Insert(GetEntity<CustomerAddress>(), new CustomerAddressModel() { CustomerId = appModel.Id, TypeOfAddress = AddressType.Home, IsPrimary = true }, userId);
            Insert(GetEntity<CustomerAddress>(), new CustomerAddressModel() { CustomerId = appModel.Id, TypeOfAddress = AddressType.HomeTown, IsPrimary = false }, userId);
            Insert(GetEntity<CustomerAddress>(), new CustomerAddressModel() { CustomerId = appModel.Id, TypeOfAddress = AddressType.Office, IsPrimary = false }, userId);
            Insert(GetEntity<CustomerAddress>(), new CustomerAddressModel() { CustomerId = appModel.Id, TypeOfAddress = AddressType.Recent, IsPrimary = false }, userId);

            return base.OnCreate(model, userId, isValid);
        }

        public Response Update(CustomerUpdateDto customerUpdateDto, Guid userId)
        {
            var customerFromRepo = Entity.Find(customerUpdateDto.Id);

            customerUpdateDto.CopyProperties(customerFromRepo);

            customerFromRepo.UpdatedAt = DateTime.Now;
            customerFromRepo.UpdatedBy = userId;

            SaveChange();

            return new Response(204, customerFromRepo, false, "Updated");
        }

        public Response ChangePassword(CustomerPasswordChangeDto customerUpdateDto, Guid userId)
        {
            var customerFromRepo = Entity.Find(customerUpdateDto.Id);

            customerUpdateDto.CopyProperties(customerFromRepo);

            customerFromRepo.UpdatedAt = DateTime.Now;
            customerFromRepo.UpdatedBy = userId;

            SaveChange();

            return new Response(204, customerFromRepo, false, "Updated");
        }

        public async Task<ResponseList<Dictionary<string, object>>> BasicInfo(Guid Id)
        {
            using (var db = new DBService(this))
            {
                return await db.FirstOrDefault(CustomerQuery.BasicInfo + Id + "'");
            }
        }
    }



    public class CustomerQuery
    {
        public static string Get()
        {
            return @"
                	   customer.[Id]
                      ,customer.[CreatedAt]
                      ,customer.[CreatedBy]
                      ,customer.[UpdatedAt]
                      ,customer.[UpdatedBy]
                      ,customer.[IsDeleted]
                      ,ISNULL(customer.[Remarks], '') [Remarks]
                      ,customer.[ActivityId]
                      ,ISNULL(customer.[Name], '') [Name]
                      ,customer.[Phone]
                      ,ISNULL(customer.[Email], '') [Email]
                      ,customer.[Cashback]
                      ,customer.[Password]
                      ,customer.[DueAmount]
                      ,ISNULL('/images/customer/profile/icon/'+customer.[ImageURL], '') [ImageURL]
                      ,customer.[RegistrationBy]
                  FROM [dbo].[Customer] customer";
        }
        public static string BasicInfo { get { return @"SELECT " + Get() + " Where customer.Id = '"; } }
    }
}
