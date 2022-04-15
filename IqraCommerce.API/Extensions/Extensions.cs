using System;
using System.Collections.Generic;
using System.Linq;
using IqraCommerce.API.Data;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<Guid> GetAllChidren(this IEnumerable<Category> list, Guid categoryId)
        {
            IList<Guid> listOfChildren = new List<Guid>();

            list.GetAllChidrenRecursion(new List<Guid>(){categoryId}, ref listOfChildren);
            
            return listOfChildren;
        }

        private static IList<Guid> GetAllChidrenRecursion(this IEnumerable<Category> categories,
                                                   IEnumerable<Guid> targetIds, 
                                                   ref IList<Guid> listOfChildren)
        {
            IList<Guid> newChildren = new List<Guid>();

           foreach (var category in categories)
            {
                if(targetIds.Contains(category.ParentId))
                    newChildren.Add(category.Id);
            }

            listOfChildren = listOfChildren.Concat(newChildren).ToList();

            if(newChildren.Count() == 0)
                return listOfChildren;
            else
                return categories.GetAllChidrenRecursion(newChildren, ref listOfChildren);
        }
    
        public static Order GenerateNewOrder(this OrderCreateDto order,
                                             OrderPaymentDto payment,
                                             Guid customerId,
                                             string orderNumber)
        {   
            return new Order()
            {
                CreatedBy = customerId,
                CustomerId = customerId,
                OrderNumber = orderNumber,
                OrderStatus = OrderStatus.Pending,
                OrderValue = payment.OrderValue,
                PaidAmount = 0,
                PayableAmount = payment.PayableAmount,
                PaymentLeft = payment.PayableAmount,
                PaymentMethod = PaymentMethod.CashOnDelivery,
                PaymentStatus = PaymentStatus.Pending,
                Remarks = order.Remarks,
                ShippingCharge = payment.ShippingCharge,
                TotalProducts = order.Products.Count(),
                TotalQuantity = order.Products.Sum(p => p.Quantity),
                TypeOfPlatForm = PlatformType.Web,
            };
        }
    
        public static IEnumerable<OrderAquiredOffer> AquiredOffers(this OrderPaymentDto payment, Guid orderId)
        {
            IList<OrderAquiredOffer> aquiredOffers = new List<OrderAquiredOffer>();

            if(payment.ProductDiscount > 0)
            {
                aquiredOffers.Add
                (
                    new OrderAquiredOffer()
                    {
                        OrderId = orderId,
                        Description = "Product discounted price",
                        IsRedeemed = true,
                        RefOfferId = Guid.Empty,
                        TypeOfOffer = OrderAquiredOfferType.Product,
                        Discount = payment.ProductDiscount
                    }
                );
            }

            // TODO: CASHBACK
            // TODO: COUPON

            return aquiredOffers;
        }
    
        public static OrderHistory OrderInitiateHistory(this Order order,
                                             OrderPaymentDto payment,
                                             Guid customerId,
                                             string message)
        {   
            return new OrderHistory()
            {
               ActivityId = order.ActivityId,
                CreatedBy = customerId,
                OrderId = order.Id,
                TypeOfAction = OrderAction.Created,
                Remarks = message
            };
        }
    }
}