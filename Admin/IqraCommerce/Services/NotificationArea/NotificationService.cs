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
using IqraCommerce.Models.NotificationArea;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.HistoryArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.UserArea
{
    public class NotificationService : IqraCommerce.Services.AppBaseService<Notification>
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
                case "Notification":
                    name = "cstmr.[Name]";
                    break;
                default:
                    name = "notification." + name;
                    break;
            }
            return base.GetName(name);
        }

        public Notification CashbackAquired(Guid orderId, string orderNumber, double cashback, double account)
        {
            var content = $"{cashback}Tk cashback added to your account, from order #{orderNumber}. Now your cashback account is {account}";
            var type = NotificationType.CashbackAquired;

            return GenerateNotification(content, type, orderId);
        }

        public Notification StatusChanged(Guid orderId, string orderNumber, OrderStatus prevState, OrderStatus currState)
        {
            var content = $"#{orderNumber} Order status changed from {prevState} to {currState}";
            var type = NotificationType.OrderStatusChanged;

            return GenerateNotification(content, type, orderId);
        }



        public CustomerNotificationModel AssignCustomer(Guid customerId, Guid notificationId)
        {
            var customerNotification = new CustomerNotificationModel
            {
                ActivityId = Guid.Empty,
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.Empty,
                CustomerId = customerId,
                IsDeleted = false,
                IsRead = false,
                NotificationId = notificationId,
                Remarks = "AUTO GENERATED",
            };

            Insert(GetEntity<CustomerNotification>(), customerNotification, Guid.Empty);

            SaveChange();

            return customerNotification;
        }

        private string GetIconURL(NotificationType type)
        {
            string url = "notification-default.png";

            switch (type)
            {
                case NotificationType.OrderPlacedByAdmin:
                    break;
                case NotificationType.OrderStatusChanged:
                    url = "status-changed.png";
                    break;
                case NotificationType.OrderCancelledByAdmin:
                    break;
                case NotificationType.OrderCancelledByCustomer:
                    break;
                case NotificationType.CustomForAll:
                    break;
                case NotificationType.CustomForSpecific:
                    break;
                case NotificationType.CashbackPending:
                    url = "cashback.png";
                    break;
                case NotificationType.CashbackAquired:
                    url = "cashback.png";
                    break;
                default:
                    break;
            }

            return url;
        }

        private string GetTitle(NotificationType type)
        {
            string title = "notification-default.png";

            switch (type)
            {
                case NotificationType.OrderPlacedByAdmin:
                    break;
                case NotificationType.OrderStatusChanged:
                    title = "Order status updated";
                    break;
                case NotificationType.OrderCancelledByAdmin:
                    break;
                case NotificationType.OrderCancelledByCustomer:
                    break;
                case NotificationType.CustomForAll:
                    break;
                case NotificationType.CustomForSpecific:
                    break;
                case NotificationType.CashbackPending:
                    title = "Cashback On Purchase";
                    break;
                case NotificationType.CashbackAquired:
                    title = "Cashback Added";
                    break;
                default:
                    break;
            }

            return title;
        }

        private Notification GenerateNotification(string content, NotificationType type, Guid referenceId)
        {
            var notification =  new Notification
            {
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.Empty,
                Content = content,
                IconURL = GetIconURL(type),
                ActivityId = Guid.Empty,
                Name = GetTitle(type),
                IsDeleted = false,
                ReferenceId = referenceId,
                TypeOfNotification = type,
                Remarks = "Auto Generated",
            };

            Insert(notification);

            SaveChange();

            return notification;
        }
    }



    public class NotificationQuery
    {
        public static string Get()
        {
            return @"";
        }
    }
}
