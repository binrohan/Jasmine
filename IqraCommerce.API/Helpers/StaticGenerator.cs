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

namespace IqraCommerce.API.Helpers
{

    public class FileCreator
    {
        public static async Task<bool> Create(string path)
        {
            //G:\Running\2021\EBonik\Customer\EBonik\IqraBase.Web\Content\HTMLViews\Index\LastPart.html
            //string path = "/Content/ImageData/Prescriptions/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
            using (var db = new DBService())
            {
                var data = await db.MultiListArr(FileCreatorQuery.Get);
                var dataStr = "var appData = " + JsonConvert.SerializeObject(data);
                var firstPart = System.IO.File.ReadAllText(path + @"Content\HTMLViews\Index\FirstPart.html");
                var lastPart = System.IO.File.ReadAllText(path + @"Content\HTMLViews\Index\LastPart.html");
                dataStr = firstPart + dataStr + lastPart;
                System.IO.File.WriteAllText(path + @"Content\HTMLViews\Index\Index.html", dataStr);

                var bytes = File.ReadAllBytes(path + @"Content\HTMLViews\Index\Index.html");
                using (FileStream fs = new FileStream(path + @"Content\HTMLViews\Index\Index.zip", FileMode.Create))
                {
                    using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
                using (FileStream fs = new FileStream(path + @"Content\HTMLViews\Index\Index.Iqra", FileMode.Create))
                {
                    using (DeflateStream zipStream = new DeflateStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            return true;
        }
        private static AppDataModel SetAppData(ResponseList<MultiListArrayModel> data) {
            AppDataModel model = new AppDataModel() { };
            var products = new Dictionary<Guid, List<Products>>();
            Guid categoryId;
            foreach (var ctgr in data.Data.Data[5])
            {
                categoryId = new Guid(ctgr[12].ToString());
                if (!products.ContainsKey(categoryId))
                {
                    products[categoryId] = new List<Products>();
                }
                products[categoryId].Add(new Products()
                {
                    Id = new Guid(ctgr[0].ToString()),
                    Name = ctgr[1].ToString(),
                    Category = ctgr[8].ToString(),
                    Discount = double.Parse(ctgr[5].ToString()),
                    GenericName = ctgr[2].ToString(),
                    UnitSalePrice = double.Parse(ctgr[4].ToString()),
                    ImagePath = ctgr[6].ToString(),
                    Suplier = ctgr[9].ToString(),
                    Strength = ctgr[3].ToString(),
                    ImageType = ctgr[7].ToString(),
                    TotalStock = double.Parse(ctgr[10].ToString()),
                });
            }

            foreach (var ctgr in data.Data.Data[0])
            {
                model.TopCategories.Add(new TopCategory() { 
                    Id=new Guid(ctgr[0].ToString()),
                    Nm= ctgr[1].ToString(),
                    Pt= ctgr[2].ToString()
                });
            }
            foreach (var ctgr in data.Data.Data[1])
            {
                categoryId = new Guid(ctgr[0].ToString());
                model.DisplayCategories.Add(new DisplayCategory()
                {
                    Id = categoryId,
                    Nm = ctgr[1].ToString(),
                    Pt = products.ContainsKey(categoryId)?products[categoryId]:new List<Products>()
                });
            }
            foreach (var ctgr in data.Data.Data[2])
            {
                categoryId = new Guid(ctgr[0].ToString());
                model.Products.Add(new DisplayCategory()
                {
                    Id = new Guid(ctgr[0].ToString()),
                    Nm = ctgr[1].ToString(),
                    Pt = products.ContainsKey(categoryId) ? products[categoryId] : new List<Products>()
                });
            }
            foreach (var ctgr in data.Data.Data[3])
            {
                if (ctgr[2].ToString() != "medium") continue;

                model.TopSlider.Add(new Slider()
                {
                    Pt = ctgr[0].ToString(),
                    Ur = ctgr[1].ToString(),
                });
            }
            foreach (var ctgr in data.Data.Data[4])
            {
                if (ctgr[2].ToString() != "medium") continue;

                model.BottomSlider.Add(new Slider()
                {
                    Pt = ctgr[0].ToString(),
                    Ur = ctgr[1].ToString(),
                });
            }
            foreach (var ctgr in data.Data.Data[6])
            {
                model.Notice.Add(ctgr[0].ToString());
            }
            foreach (var ctgr in data.Data.Data[7])
            {
                model.Perks.Add(new Perk() {
                    Title = ctgr[0].ToString(),
                    Content = ctgr[1].ToString(),
                    IconPath = ctgr[2].ToString(),
                    Type = ctgr[3].ToString()
                });
            }
            return model;
        }
        public static async Task<bool> CreateAppData(string path)
        {
            //G:\Running\2021\EBonik\Customer\EBonik\IqraBase.Web\Content\HTMLViews\Index\LastPart.html
            //string path = "/Content/ImageData/Prescriptions/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
            using (var db = new DBService())
            {
                var data = await db.MultiListArr(FileCreatorQuery.AppData);
                // var dataStr = JsonConvert.SerializeObject(SetAppData(data));
                SetWebAppData(data, path);
                // System.IO.File.WriteAllText(path + @"Content\HTMLViews\Index\AppData.html", dataStr);
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
        public static void CreateAppCss(string path)
        {
            var files = new List<string>() { { @"Content\assets\lib\bootstrap\css\bootstrap.min.css" },
                { @"Content\assets\lib\font-awesome\css\font-awesome.min.css" },
                { @"Content\assets\lib\jquery.bxslider\jquery.bxslider.css" },
                {@"Content\assets\css\animate.css" },
                {@"Content\assets\css\style.css" }
            };

            string css = "";

            foreach (var file in files)
            {
                css += System.IO.File.ReadAllText(path + file);
            }

            if (File.Exists(path + @"Content\assets\css\Appcss.png"))
            {
                File.Delete(path + @"Content\assets\css\Appcss.png");
            }
            //using (var stream = new MemoryStream())
            //{
            //    var writer = new StreamWriter(stream);
            //    writer.Write(css);
            //    writer.Flush();
            //    stream.Position = 0;
            //    stream.
            //}
            FileInfo fi = new FileInfo(path + @"Content\assets\css\Appcss.png");
            fi.Create();
            System.IO.File.WriteAllText(path + @"Content\assets\css\Appcss.png", css);
            var bytes = File.ReadAllBytes(path + @"Content\assets\css\Appcss.png");
            using (FileStream fs = new FileStream(path + @"Content\assets\css\AppcssZip.png", FileMode.Create))
            {
                using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                {
                    zipStream.Write(bytes, 0, bytes.Length);
                }
            }
            using (FileStream fs = new FileStream(path + @"Content\assets\css\AppcssDef.png", FileMode.Create))
            {
                using (DeflateStream zipStream = new DeflateStream(fs, CompressionMode.Compress, false))
                {
                    zipStream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
    public class FileCreatorQuery
    {
        public static class Max { 
            public static int TopCategory { get { return 30; } }
            public static int DisplayCategory { get { return 30; } }
            public static int SpecialProducts { get { return 30; } }
            public static int TopBanner { get { return 10; } }
            public static int DisplayBanner { get { return 10; } }
            public static int CategoryProduct { get { return 20; } }
        }
        public static string Get
        {
            get
            {
             return @"

-- Banners
SELECT [Id]
      ,[Rank]
      ,[Size]
      ,[ImageURL]
      ,[Link]
  FROM [dbo].[Banner] banner
  ORDER BY [Rank]

SELECT [Id]
      ,[Name]
      ,[Rank]
      ,[ProductCategoryId]
  FROM [dbo].[ProductSubCategory]
  where [IsDeleted] = 0 And [ProductCategoryId] in (SELECT top 12 [Id] FROM [dbo].[ProductCategory] where [IsDeleted] = 0 order by [Rank] desc)
  order by [Rank] desc
  
SELECT [Id]
      ,[Name]
      ,[Rank]
  FROM [dbo].[ProductSubCategory]
  where [IsDeleted] = 0 And [ProductCategoryId] in (SELECT top 1 [Id] FROM [dbo].[ProductCategory] where [IsDeleted] = 0 order by [Rank] desc)
  order by [Rank] desc

  Select top 12 itm.[Id]
      ,itm.[Name]
      ,itm.[GenericName]
      ,itm.[Strength]
      ,itm.[UnitSalePrice]
      ,itm.[Discount]
      ,IsNull(itm.[ImagePath], ctgr.[ImagePath]) [ImagePath]
      ,Case when itm.[ImagePath] is null then 0 else 1 end [ImageType]
	  ,[ctgr].Name [Category]
	  ,[splr].Name [Suplier]
      ,itm.[TotalStock]
  FROM [dbo].[Item] itm
  inner join [dbo].[SpecialProduct] spclpdct on itm.[Id]=spclpdct.[ProductId] And spclpdct.[IsDeleted] = 0
  left join [dbo].[Category] [ctgr] on itm.[CategoryId]=[ctgr].Id 
  left join [dbo].[Suplier] [splr] on itm.[SuplierId]=[splr].Id
where spclpdct.[IsDeleted]= 0 And spclpdct.[ProductType]= 'Special'
Order by spclpdct.[Rank]


Select top 24 itm.[Id]
      ,itm.[Name]
      ,itm.[GenericName]
      ,itm.[Strength]
      ,itm.[UnitSalePrice]
      ,itm.[Discount]
      ,IsNull(itm.[ImagePath], ctgr.[ImagePath]) [ImagePath]
      ,Case when itm.[ImagePath] is null then 0 else 1 end [ImageType]
	  ,[ctgr].Name [Category]
	  ,[splr].Name [Suplier]
      ,itm.[TotalStock]
  FROM [dbo].[Item] itm
  inner join [dbo].[SpecialProduct] spclpdct on itm.[Id]=spclpdct.[ProductId] And spclpdct.[IsDeleted] = 0
  left join [dbo].[Category] [ctgr] on itm.[CategoryId]=[ctgr].Id 
  left join [dbo].[Suplier] [splr] on itm.[SuplierId]=[splr].Id
where spclpdct.[IsDeleted]= 0 And  spclpdct.[ProductType]= 'Featured'
Order by spclpdct.[Rank]

Select top 1  bnr.[Id]
      ,bnr.[Name]
      ,bnr.[Image]
      ,bnr.[CreatedAt]
       FROM [dbo].[Banner] bnr
 where [IsDeleted]= 0
Order by bnr.[CreatedAt]

SELECT ntc.[Id]
      ,ntc.[Name]
      ,ntc.[NoticeContent]
	  ,ntc.[Status]
  FROM [dbo].[Notice] ntc
  where ntc.Status = 'Activate' And ntc.[IsDeleted] = 0
  and  ntc.ActiveAt <= CONVERT(date, getdate()) and ntc.EndAt >=  CONVERT(date, getdate())
Order by ntc.[CreatedAt]

";
            }
        }
        public static string AppData
        {
            get
            {
                return @"
-- Banners
SELECT [Id]
      ,[Rank]
      ,[Size]
      ,[ImageURL]
      ,[Link]
  FROM [dbo].[Banner] banner
  WHERE IsDeleted = 0 AND IsVisible = 1
  ORDER BY [Rank]

--Notice
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