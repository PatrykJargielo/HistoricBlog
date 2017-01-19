using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Config
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetAppSetting(string key)
        {
            var value = System.Configuration.ConfigurationManager.AppSettings[key];
            return value;
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key];
        }
    }
}
