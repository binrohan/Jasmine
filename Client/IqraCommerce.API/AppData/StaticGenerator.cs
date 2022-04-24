using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using IqraCommerce.API.Constants;
using IqraCommerce.API.Data;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Helpers;
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

                var bytes = File.ReadAllBytes(path + @"wwwroot/generated-static/AppData.html");

                using (FileStream fs = new FileStream(path + @"wwwroot/generated-static/AppData.zip", FileMode.Create))
                {
                    using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
                using (FileStream fs = new FileStream(path + @"wwwroot/generated-static/AppData.Iqra", FileMode.Create))
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
            var homeDisplay = ArrayGenerator.HomeDisplay(data.Data.Data[1]);
            List<object> Data = new List<object>() { 
                categories, // Display
                data.Data.Data[0], // Notice
                homeDisplay, // Home Display
            };

            var appDataJSON = JsonConvert.SerializeObject(Data);
            var dataStr = "var APP_DATA = " + appDataJSON +";";

            System.IO.File.WriteAllText(path + @"wwwroot/generated-static/appdata.json", appDataJSON);

            var firstPart = System.IO.File.ReadAllText(path + @"wwwroot/generated-static/FirstPart.html");
            var lastPart = System.IO.File.ReadAllText(path + @"wwwroot/generated-static/LastPart.html");
            dataStr = firstPart + dataStr + lastPart;
            System.IO.File.WriteAllText(path + @"wwwroot/index.html", dataStr);

            return Data;
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
                        ,'"+ Config.AppSetting(Supdirs.directories, Subdirs.banner, Key.original) +@"'+[ImageURL] [ImageURL]
                        ,[Link]
                    FROM [dbo].[Banner] banner
                    WHERE IsDeleted = 0 AND IsVisible = 1 AND TypeOfBanner = " + (int)BannerType.MainBanner + @"
                    ORDER BY [Rank]

                    -- ### Home Page Display With Product ### [2]
                    SELECT D.[Id]
                    ,D.[Name] [DisplayName]
                    ,P.[Id] [DisplayId]
                    ,P.[DisplayName] [ProductDisplayName]
                    ,P.[PackSize]
                    ,'PRIMARY IMAGE URL GOES HERE' [ImageURL]
                    ,P.[CurrentPrice]
                    ,P.[OriginalPrice]
                    ,P.[DiscountedPrice]
                    ,P.[DiscountedPercentage]
                    ,P.[StockUnit]
                    ,P.[UnitId] [UnitId]
					,U.Name [UnitName]
                    FROM [dbo].[Display] D
                    RIGHT JOIN [DisplayProduct] DP ON DP.DisplayId = D.Id
                    LEFT JOIN [Product] P ON DP.ProductId = P.Id
                    LEFT JOIN [Unit] U ON U.Id = P.UnitId
                    WHERE D.[IsDeleted] = 0 AND D.[IsVisible] = 1 AND
                            DP.IsDeleted = 0
                    ORDER BY D.[Rank], P.Rank

                
                ";
            }
        }
    }
}