using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.EnvironmentConfiguration
{
    public class EnvironmentConfig
    {
        public static IConfigurationRoot builderRoot;
        private readonly IConfiguration _conf;
        public EnvironmentConfig(IConfiguration conf)
        {
            this._conf = conf;
        }
        public static string GetAppSetting(string key)
        {
            if (builderRoot == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builderRoot = builder.Build();
            }
            return builderRoot.GetSection(key).ToString();
        }
        //Birinci overload ile veri alınamazsa buradaki methodla alınabilir
      
        public static string GetConnectionString(string key)
        {
            if (builderRoot == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builderRoot = builder.Build();
            }
            return builderRoot.GetConnectionString(key);
        }

        public static List<IConfigurationSection> GetConfigArray(string key)
        {
            if (builderRoot == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builderRoot = builder.Build();
            }
            var res = builderRoot.GetSection(key).GetChildren().ToList();
            return builderRoot.GetSection(key).GetChildren().ToList();
        }
    }
}
