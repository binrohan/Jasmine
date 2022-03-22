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
        
        
        public static async Task<bool> CreateAppData(string path)
        {
            using (var db = new DBService())
            {
                var data = await db.MultiListArr(Query.AppData);

                SetWebAppData(data, path);

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
            return true;
        }
        private static AppDataModel SetWebAppData(ResponseList<MultiListArrayModel> data, string path)
        {
            AppDataModel model = new AppDataModel() { };
            var products = new Dictionary<Guid, List<object>>();
            List<List<List<object>>> Data = new List<List<List<object>>>() { 
                data.Data.Data[0], 
                data.Data.Data[1], 
                // data.Data.Data[2], 
                // data.Data.Data[3], 
                // data.Data.Data[4],
                // data.Data.Data[6],
                // data.Data.Data[7],
                // data.Data.Data[8]
            };
            // Guid categoryId;
            // foreach (var ctgr in data.Data.Data[5])
            // {
            //     categoryId = new Guid(ctgr[12].ToString());
            //     if (!products.ContainsKey(categoryId))
            //     {
            //         products[categoryId] = new List<object>();
            //     }
            //     products[categoryId].Add(ctgr);
            // }
            // foreach (var ctgr in data.Data.Data[1])
            // {
            //     categoryId = new Guid(ctgr[0].ToString());
            //     ctgr[2] = products.ContainsKey(categoryId) ? products[categoryId] : new List<object>();
            // }
            // foreach (var ctgr in data.Data.Data[2])
            // {
            //     categoryId = new Guid(ctgr[0].ToString());
            //     ctgr[2] = products.ContainsKey(categoryId) ? products[categoryId] : new List<object>();
            // }
            // #region SetCategory Slider

            // products = new Dictionary<Guid, List<object>>();
            // foreach (var ctgr in data.Data.Data[8])
            // {
            //     categoryId = new Guid(ctgr[0].ToString());
            //     if (!products.ContainsKey(categoryId))
            //     {
            //         products[categoryId] = new List<object>();
            //     }
            //     products[categoryId].Add(new object[2] { ctgr[0] , ctgr[1] });
            // }
            // foreach (var ctgr in data.Data.Data[1])
            // {
            //     categoryId = new Guid(ctgr[0].ToString());
            //     ctgr[3] = products.ContainsKey(categoryId) ? products[categoryId] : new List<object>();
            // }
            // #endregion

            var dataStr = "var appData = " + JsonConvert.SerializeObject(Data)+";";
            var firstPart = System.IO.File.ReadAllText(path + @"wwwroot/FirstPart.html");
            var lastPart = System.IO.File.ReadAllText(path + @"wwwroot/LastPart.html");
            dataStr = firstPart + dataStr + lastPart;
            System.IO.File.WriteAllText(path + @"index.html", dataStr);

            return model;
        }
    }
    public class Query
    {
        public static string AppData
        {
            get
            {
                return @"
                    -- ### Banners ###
                    SELECT [Id]
                        ,[Rank]
                        ,[Size]
                        ,[ImageURL]
                        ,[Link]
                    FROM [dbo].[Banner] banner
                    WHERE IsDeleted = 0 AND IsVisible = 1
                    ORDER BY [Rank]

                    -- ### Notice ###
                    SELECT [Id]
                        ,[Rank]
                        ,[Content]
                    FROM [dbo].[Notice]
                    WHERE GETDATE() > StartDate AND GETDATE() < EndDate AND IsDeleted = 0 AND IsVisible = 1
                    ORDER BY [Rank]

                ";
            }
        }
    }
}