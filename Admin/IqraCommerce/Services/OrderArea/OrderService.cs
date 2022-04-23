using IqraBase.Service;
using IqraCommerce.Entities.OrderArea;
using IqraCommerce.Models.OrderArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.OrderArea
{
    public class OrderService : IqraCommerce.Services.AppBaseService<Order>
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
                    name = "[order]." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[CreatedAt] desc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, OrderQuery.Get());
            }
        }

        public async Task<ResponseJson> ChangeStatus(OrderModel model, Guid userId)
        {
            return await CallbackAsync((response) =>
            {
                var Order = GetById(model.Id);
                if (Order != null)
                {
                    Order.Remarks = model.Remarks;
                    Order.OrderStatus = model.OrderStatus;
                    Order.UpdatedAt = DateTime.Now;
                    Order.UpdatedBy = userId;
                    SaveChange();
                }
                else
                {
                    response.IsError = true;
                    response.Id = -4;
                    response.Msg = "Order not found.";
                }
            });
        }

    }

    public class OrderQuery
    {
        public static string Get()
        {
            return @"[order].[Id]
                  ,[order].[CreatedAt]
                  ,[order].[CreatedBy]
                  ,[order].[UpdatedAt]
                  ,[order].[UpdatedBy]
                  ,[order].[IsDeleted]
                  ,ISNULL([order].[Remarks], ' ') [Remarks]
                  ,[order].[ActivityId]
                  ,[order].[OrderNumber]
                  ,[order].[CustomerId]
                  ,[order].[OrderStatus]
                  ,[order].[PaymentStatus]
                  ,[order].[OrderValue]
                  ,[order].[ShippingCharge]
                  ,[order].[PayableAmount]
                  ,[order].[PaidAmount]
                  ,[order].[PaymentLeft]
                  ,[order].[TotalProducts]
                  ,[order].[TotalQuantity]
                  ,[order].[PaymentMethod]
                  ,[order].[TypeOfPlatForm]
	              ,customer.Phone [CustomerPhone]
	              ,('Area: ' + ISNULL(upazila.Name, 'Not Selected') + ', District: ' + ISNULL(district.Name, 'Not Selected') + ', Province: ' + ISNULL(province.Name, 'Not Selected') + ', Local: ' + ISNULL(shippingaddress.Remarks, 'Not Provided')) [Address]
              FROM [dbo].[Order] AS [order]
              LEFT JOIN [dbo].[Customer] customer ON customer.Id = [order].CustomerId
              LEFT JOIN [dbo].[ShippingAddress] shippingaddress ON shippingaddress.OrderId = [order].Id
              LEFT JOIN [dbo].[Province] province ON province.Id = shippingaddress.ProvinceId
              LEFT JOIN [dbo].District district ON district.Id = shippingaddress.DistrictId
              LEFT JOIN [dbo].Upazila upazila ON upazila.Id = shippingaddress.UpazilaId";
        }
    }
}
