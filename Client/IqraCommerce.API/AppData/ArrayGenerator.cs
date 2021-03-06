using System;
using System.Collections.Generic;

namespace IqraCommerce.API.AppData
{
    public static class ArrayGenerator
    {
        public static List<object> HomeDisplay(List<List<object>> list)
        {
            var output = new List<object>();
            var d = new Dictionary<string, HomeCategory>();
            foreach (var item in list)
            {
               var id = item[0].ToString();
               if(!d.ContainsKey(id))
               {
                   d.Add(id, new HomeCategory(item[0], item[1]));
               }

               d[id].Product.Add(new HomeProduct(item[2],
                                                 item[3],
                                                 item[4],
                                                 item[5],
                                                 item[6],
                                                 item[7],
                                                 item[8],
                                                 item[9],
                                                 item[10],
                                                 item[11],
                                                 item[12]));
            }

            foreach (var x in d)
            {
                var v = x.Value;
                IList<object> p = new List<object>();
                foreach (var pr in v.Product)
                {
                    p.Add(new List<object>()
                    {
                        pr.Id,
                        pr.DisplayName,
                        pr.PackSize,
                        pr.ImageURL,
                        pr.CurrentPrice,
                        pr.OriginalPrice,
                        pr.DiscountedPrice,
                        pr.DiscountedPercentage,
                        pr.StockUnit,
                        pr.UnitId,
                        pr.UnitName
                    });
                }
                IList<object> c = new List<object>()
                {
                    v.Id, v.Name, p
                };

                output.Add(c);
            }

            return output;
        }
    }

    public class HomeCategory
    {
        public HomeCategory(object id, object name)
        {
            Id = id;
            Name = name;
            Product = new List<HomeProduct>();
        }
        public object Id { get; set; }
        public object Name { get; set; }
        public IList<HomeProduct> Product { get; set; }
    }

    public class HomeProduct
    {
        public HomeProduct(object id,
                           object displayName,
                           object packSize,
                           object imageURL,
                           object currentPrice,
                           object originalPrice,
                           object discountedPrice,
                           object discountedPercentage,
                           object stockUnit,
                           object unitId,
                           object unitName)
        {
            Id = id;
            DisplayName = displayName;
            PackSize = packSize;
            ImageURL = imageURL;
            CurrentPrice = currentPrice;
            OriginalPrice = originalPrice;
            DiscountedPrice = discountedPrice;
            DiscountedPercentage = discountedPercentage;
            StockUnit = stockUnit;
            UnitId = unitId;
            UnitName = unitName;

        }
        public object Id { get; set; }
        public object DisplayName { get; set; }
        public object PackSize { get; set; }
        public object ImageURL { get; set; }
        public object CurrentPrice { get; set; }
        public object OriginalPrice { get; set; }
        public object DiscountedPrice { get; set; }
        public object DiscountedPercentage { get; set; }
        public object StockUnit { get; set; }
        public object UnitId { get; set; }
        public object UnitName { get; set; }
    }
}