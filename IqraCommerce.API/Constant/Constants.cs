using Microsoft.Extensions.Configuration;

namespace IqraCommerce.API.Constants
{
    public static class Dirs
    {
        public readonly static string banner = "Banner";
        public readonly static string product = "Product";
        public readonly static string showcase = "Showcase";
        public readonly static string productHighlight = "ProductHighlight";
    }

    public static class ImageSize
    {
        public readonly static string original = "Original";
        public readonly static string small = "Small";
        public readonly static string icon = "Icon";

    }

    public class Dir
    {
        private readonly IConfiguration _config;
        public Dir(IConfiguration config)
        {
            _config = config;
        }

        public string Image(string dir, string size)
        {
            return _config.GetSection("Directories").GetSection(dir)[size];
        }

    }
}