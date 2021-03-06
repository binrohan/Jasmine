using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IqraCommerce.API.Constants;
using IqraCommerce.API.Data;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Helpers;

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
    
        public static IList<OrderProduct> Order(this IEnumerable<Product> products,
                                                IEnumerable<OrderProductDto> orderedProducts,
                                                Guid orderId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, OrderProduct>()
                                                            .ForMember(dest => dest.Id,
                                                                        opt => opt.Ignore()));
            IMapper _mapper =  new Mapper(config);

            var orderProducts = new List<OrderProduct>();
            
            foreach (var product in products)
            {
                var orderProduct = _mapper.Map<OrderProduct>(product);

                orderProduct.OrderId = orderId;

                var orderedProduct = orderedProducts.First(p => p.Id == product.Id);

                orderProduct.Quantity = orderedProduct.Quantity;
                orderProduct.Amount = orderedProduct.Quantity * product.CurrentPrice;
                orderProduct.Discount = orderedProduct.Quantity * product.DiscountedPrice;

                orderProducts.Add(orderProduct);
            }

            return orderProducts;
        }

        public static string PrimaryImageURL(this IList<ProductImage> images)
        {
            if(images.Count <= 0 ) return null;

            var image = images.FirstOrDefault(i => i.IsPrimary) ?? images[0];

            return Config.AppSetting(Supdirs.directories, Subdirs.productHighlight, Key.small) + image.ImageURL;
        }
    }
}