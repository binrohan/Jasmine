using EBonik.Data.Entities;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using EBonik.Data.Models.ContactArea;
using EBonik.Data.Models.UserArea;
using IqraBase.Data;
using IqraBase.Data.Models;
using IqraBase.Service;
using IqraCommerce.Data;
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
    }

    

    public class NotificationQuery
    {
        public static string Get()
        {
            return @"";
        }
    }
}
