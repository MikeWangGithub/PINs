using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PINs.Tools
{
    public class AppConfig
    {
        /// <summary>
        /// return  the value of the item(key) in  *.exe.config files appSettings configuration
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppConfig(string strKey)
        {
            //if(ConfigurationManager.AppSettings.getvalue
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.Trim().ToLower() == strKey.Trim().ToLower())
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return "";
        }
    }
}
