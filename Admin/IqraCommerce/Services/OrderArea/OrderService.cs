using EBonik.Data.Entities.UserArea;
using IqraBase.Service;
using IqraCommerce.Data;
using IqraCommerce.DTOs;
using IqraCommerce.Entities.OrderArea;
using IqraCommerce.Entities.PromotionArea;
using IqraCommerce.Helpers;
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

        public async Task<ResponseJson> ChangeStatus(OrderStatusChangeDto order, Guid userId)
        {
            return await CallbackAsync((response) =>
            {
                var orderFromRepo = GetById(order.Id);

                var prevStatus = orderFromRepo.OrderStatus;

                if (orderFromRepo != null)
                {
                    orderFromRepo.OrderStatus = order.OrderStatus;
                    orderFromRepo.UpdatedAt = DateTime.Now;
                    orderFromRepo.UpdatedBy = userId;


                    OrderHistory history = new OrderHistory()
                    {
                        ActivityId = order.ActivityId,
                        CreatedAt = DateTime.Now,
                        CreatedBy = userId,
                        Remarks = order.Remarks,
                        OrderId = order.Id,
                        TypeOfAction = order.OrderStatus
                        == OrderStatus.CancelledByAdmin ? OrderAction.CancelledByAdmin : OrderAction.StatusChanged,
                        Name = OrderHistoryHelper.GenerateHistoryMessage(prevStatus, order.OrderStatus)
                    };

                    GetEntity<OrderHistory>().Add(history);

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

        public async Task<ResponseJson> PaymentEntry(PaymentEntryDto payment, Guid userId)
        {
            return await CallbackAsync((response) =>
            {
                var orderFromRepo = GetById(payment.Id);
                var customer = GetEntity<Customer>().Find(orderFromRepo.CustomerId);

                var prevStatus = orderFromRepo.PaymentStatus;
                var prevPaid = orderFromRepo.PaidAmount;

                if (orderFromRepo != null)
                {
                    orderFromRepo.UpdatedAt = DateTime.Now;
                    orderFromRepo.UpdatedBy = userId;

                    orderFromRepo.PaidAmount += payment.Amount;
                    orderFromRepo.PaymentLeft = orderFromRepo.PayableAmount - orderFromRepo.PaidAmount;
                    orderFromRepo.PaymentStatus = orderFromRepo.PaymentLeft > 0 ? PaymentStatus.PartiallyPaid : PaymentStatus.Paid;


                    OrderHistory history = new OrderHistory()
                    {
                        ActivityId = payment.ActivityId,
                        CreatedAt = DateTime.Now,
                        CreatedBy = userId,
                        Remarks = payment.Remarks,
                        OrderId = payment.Id,
                        TypeOfAction = prevStatus == orderFromRepo.PaymentStatus ? OrderAction.PaymentEntry : OrderAction.PaymentStatusChanged,
                        Name = prevStatus != orderFromRepo.PaymentStatus ?
                        $"Payment status changed from {prevStatus} To {orderFromRepo.PaymentStatus} after payment {payment.Amount}Tk"
                        : $"Paid amount updated from {prevPaid}Tk to {orderFromRepo.PaidAmount}Tk"
                    };


                    PaymentHistory paymentHistory = new PaymentHistory()
                    {
                        ActivityId = payment.ActivityId,
                        Amount = payment.Amount,
                        CreatedAt = DateTime.Now,
                        CreatedBy = userId,
                        CustomerId = orderFromRepo.CustomerId,
                        Medium = PaymentMedium.Cash,
                        ActionIsRefunding = false,
                        OrderId = orderFromRepo.Id,
                        Reference = payment.Reference,
                    };

                    if(orderFromRepo.PaymentStatus == PaymentStatus.Paid && orderFromRepo.OrderStatus == OrderStatus.Delivered)
                    {
                        var cashbackRegister = GetEntity<CashbackRegister>().FirstOrDefault(c => c.OrderId == orderFromRepo.Id && c.CustomerId == customer.Id);

                        customer.Cashback += cashbackRegister.Amount;
                    }

                    customer.DueAmount -= payment.Amount;

                    GetEntity<PaymentHistory>().Add(paymentHistory);
                    GetEntity<OrderHistory>().Add(history);

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
