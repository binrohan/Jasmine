using System;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using static IqraCommerce.API.Constants.ImageDir;

namespace IqraCommerce.API.Helpers
{
    public class ImageManager
    {
        private string[] sizeNames = { ImageSize.Original.ToString(), ImageSize.Small.ToString(), ImageSize.Icon.ToString() };
        private int[] sizes = { 0, 480, 200 };
        private string rootDirectory = "Directories";
        private readonly IConfiguration _config;

        public ImageManager(IConfiguration config)
        {
            _config = config;
        }

        public string Store(IFormFile image, string directory)
        {
            var path = _config.GetSection(rootDirectory).GetSection(directory);
            var splitedName = image.FileName.Split('.');
            var imageName = Guid.NewGuid().ToString() + "." + splitedName[splitedName.Length - 1];

            for (int i = 0; i < 3; ++i)
            {
                if (!Directory.Exists(path[sizeNames[i]]))
                    Directory.CreateDirectory(path[sizeNames[i]]);

                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);

                    var fileBytes = memoryStream.ToArray();

                    var imageStream = Image.FromStream(memoryStream);

                    var transformedImage = imageStream;

                    if ((imageStream.Width > sizes[i] || imageStream.Height > sizes[i]) && sizes[i] != 0)
                    {
                        var ratioX = (double)sizes[i] / imageStream.Width;
                        var ratioY = (double)sizes[i] / imageStream.Height;

                        var ratio = Math.Min(ratioX, ratioY);

                        var newWidth = (int)(imageStream.Width * ratio);
                        var newHeight = (int)(imageStream.Height * ratio);

                        transformedImage = new Bitmap(newWidth, newHeight);

                        using (var graphics = Graphics.FromImage(transformedImage))
                        {
                            graphics.DrawImage(imageStream, 0, 0, newWidth, newHeight);
                        }
                    }

                    transformedImage.Save(path[sizeNames[i]] + imageName);
                }
            }

            return imageName;
        }

        public object getImageUrls(string imageName, string path)
        {
            return new
            {
                Origianl = imageUrl(imageName, path, ImageSize.Original.ToString()),
                Small = imageUrl(imageName, path, ImageSize.Small.ToString()),
                Icon = imageUrl(imageName, path, ImageSize.Icon.ToString())
            };
        }
        
        public string imageUrl(string imageName, string path, string size)
        {
            var url = _config.GetSection(path)[size];

            return "/" + url + imageName;
        }
    }
}