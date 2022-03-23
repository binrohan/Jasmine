using System;
using System.Collections.Generic;

namespace IqraCommerce.API.AppData
{
    public static class ArrayGenerator
    {
        public static List<object> HomeCategories(List<List<object>> list)
        {
            var output = new List<object>();
            var d = new Dictionary<string, HomeCategory>();
            foreach (var item in list)
            {
               var id = item[0].ToString();
               if(!d.ContainsKey(id))
               {
                   d.Add(id, new HomeCategory(item[0], item[1], item[2]));
               }

               d[id].Product.Add(new HomeProduct(item[3], item[4], item[5], item[6], item[7], item[8], item[9], item[10], item[11], item[12], item[13], item[14], item[15]));
            }

            foreach (var x in d)
            {
                var v = x.Value;
                IList<object> p = new List<object>();
                foreach (var pr in v.Product)
                {
                    p.Add(new List<object>()
                    {
                        pr.Id, pr.Name, pr.DisplayName, pr.PackSize, pr.PackSize, pr.ImageURL, pr.CurrentPrice, pr.OriginalPrice, pr.DiscountedPrice, pr.DiscountedPercentage, pr.StockUnit, pr.Rank, pr.BrandId, pr.UnitId
                    });
                }
                IList<object> c = new List<object>()
                {
                    v.Id, v.Name, v.Rank, p
                };

                output.Add(c);
            }

            return output;
        }
    }

    public class HomeCategory
    {
        public HomeCategory(object id, object name, object rank)
        {
            Id = id;
            Name = name;
            Rank = rank;
            Product = new List<HomeProduct>();
        }
        public object Id { get; set; }
        public object Name { get; set; }
        public object Rank { get; set; }
        public IList<HomeProduct> Product { get; set; }
    }

    public class HomeProduct
    {
        public HomeProduct(object id,
                           object name,
                           object displayName,
                           object packSize,
                           object imageURL,
                           object currentPrice,
                           object originalPrice,
                           object discountedPrice,
                           object discountedPercentage,
                           object stockUnit,
                           object rank,
                           object brandId,
                           object unitId)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            PackSize = packSize;
            ImageURL = imageURL;
            CurrentPrice = currentPrice;
            OriginalPrice = originalPrice;
            DiscountedPrice = discountedPrice;
            DiscountedPercentage = discountedPercentage;
            StockUnit = stockUnit;
            Rank = rank;
            BrandId = brandId;
            UnitId = unitId;

        }
        public object Id { get; set; }
        public object Name { get; set; }
        public object DisplayName { get; set; }
        public object PackSize { get; set; }
        public object ImageURL { get; set; }
        public object CurrentPrice { get; set; }
        public object OriginalPrice { get; set; }
        public object DiscountedPrice { get; set; }
        public object DiscountedPercentage { get; set; }
        public object StockUnit { get; set; }
        public object Rank { get; set; }
        public object BrandId { get; set; }
        public object UnitId { get; set; }
    }
}