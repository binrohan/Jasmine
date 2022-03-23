using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.Services;
using IqraService.DB;
using IqraService.Search;
using Newtonsoft.Json;

namespace IqraCommerce.API.AppData
{

    public class FileCreator
    {
        
        
        public static async Task<object> CreateAppData(string path, IList<object> categories)
        {
            object output;
            using (var db = new DBService())
            {
                var data = await db.MultiListArr(Query.AppData);

                output = SetWebAppData(data, path, categories);

                var bytes = File.ReadAllBytes(path + @"wwwroot/AppData.html");

                using (FileStream fs = new FileStream(path + @"wwwroot/AppData.zip", FileMode.Create))
                {
                    using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
                using (FileStream fs = new FileStream(path + @"wwwroot/AppData.Iqra", FileMode.Create))
                {
                    using (DeflateStream zipStream = new DeflateStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            return output;
        }
        private static object SetWebAppData(ResponseList<MultiListArrayModel> data, string path, IList<object> categories)
        {
            AppDataModel model = new AppDataModel() { };
            var homeCategories = ArrayGenerator.HomeCategories(data.Data.Data[2]);

            var homeCateogriesFromRepo = data.Data.Data[2];

            


            


            List<object> Data = new List<object>() { 
                categories, 
                data.Data.Data[0], 
                data.Data.Data[1], 
                homeCategories, 
                // data.Data.Data[3], 
                // data.Data.Data[4],
                // data.Data.Data[6],
                // data.Data.Data[7],
                // data.Data.Data[8]
            };

            var dataStr = "var appData = " + JsonConvert.SerializeObject(Data)+";";
            var firstPart = System.IO.File.ReadAllText(path + @"wwwroot/FirstPart.html");
            var lastPart = System.IO.File.ReadAllText(path + @"wwwroot/LastPart.html");
            dataStr = firstPart + dataStr + lastPart;
            System.IO.File.WriteAllText(path + @"index.html", dataStr);

            return data.Data.Data[2];
        }
    }
    public class Query
    {
        public static string AppData
        {
            get
            {
                return @"
                    -- ### Banners ### [0]
                    SELECT [Id]
                        ,[Rank]
                        ,[Size]
                        ,[ImageURL]
                        ,[Link]
                    FROM [dbo].[Banner] banner
                    WHERE IsDeleted = 0 AND IsVisible = 1
                    ORDER BY [Rank]

                    -- ### Notice ### [1]
                    SELECT [Id]
                        ,[Rank]
                        ,[Content]
                    FROM [dbo].[Notice]
                    WHERE GETDATE() > StartDate AND GETDATE() < EndDate AND IsDeleted = 0 AND IsVisible = 1
                    ORDER BY [Rank]

                    -- ### Home Page Categories With Product ### [2]
                    SELECT C.[Id]
                    ,C.[Name]
                    ,C.[Rank]
                    ,P.[Id]
                    ,P.[Name]
                    ,P.[DisplayName]
                    ,P.[PackSize]
                    ,P.[ImageURL]
                    ,P.[CurrentPrice]
                    ,P.[OriginalPrice]
                    ,P.[DiscountedPrice]
                    ,P.[DiscountedPercentage]
                    ,P.[StockUnit]
                    ,P.[Rank]
                    ,P.[BrandId]
                    ,P.[UnitId]
                FROM [dbo].[Category] C
                RIGHT JOIN [ProductCategory] PC ON PC.CategoryId = C.Id
                LEFT JOIN [Product] P ON PC.ProductId = P.Id
                WHERE C.[IsDeleted] = 0 AND C.[IsVisible] = 1 AND C.[IsVisibleInHome] = 1 AND
                        PC.IsDeleted = 0
                ORDER BY C.[Rank], P.Rank
                ";
            }
        }
    }
}