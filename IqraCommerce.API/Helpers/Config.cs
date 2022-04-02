using System.IO;
using Microsoft.Extensions.Configuration;

namespace IqraCommerce.API.Helpers
{
    public class Config
    {

        private static Config _appSettings;

        public string appSettingValue { get; set; }

        public static string AppSetting(string sub, string Key)
        {
          _appSettings = GetCurrentSettings(sub, Key);
          return _appSettings.appSettingValue;
        }

        public Config(IConfiguration config, string Key)
        {
            this.appSettingValue = config.GetValue<string>(Key);
        }

        public static Config GetCurrentSettings(string sub, string Key)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            if(string.IsNullOrEmpty(sub))
                return new Config(configuration.GetSection("Directories"), Key);
            


            return new Config(configuration.GetSection("Directories").GetSection(sub), Key);

        }
    }
}