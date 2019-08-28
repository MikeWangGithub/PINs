using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINs.Tools
{
    //public class ParameterGetNumber : ICloneable
    //{
    //    public List<string> Regex { get; set; }

    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }
    //    public ParameterGetNumber()
    //    {
    //        Regex = "";
    //    }
    //}
    public class ParameterSystem : ICloneable
    {
        public bool Debug { get; }
        public string LoggerClassName { get; }

        public List<string> Regex { get; }
        public string RightFormat { get; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public ParameterSystem()
        {
            if (AppConfig.GetAppConfig("debug").Trim().ToLower() == "true")
            {
                Debug = true;
            }
            else { Debug = false; }
            LoggerClassName = AppConfig.GetAppConfig("Logger");
            string RegexStr = AppConfig.GetAppConfig("ObviousNumber");
            if (Regex == null)
            {
                Regex = new List<string>();
            }
            Regex = RegexStr.Split('|').ToList<string>();
            RightFormat = AppConfig.GetAppConfig("RightNumber");

        }
    }
    public enum PINThreadName { GetNumber = 1 } 
}
