using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using PINs.GlobalData;

namespace PINs.GlobalData
{
    public static class LoggerHelper
    {
        public static ILog log;
        private static object LockObect = new object();
        public static void Initial(Object obj)
        {
            if (log == null)
            {
                try
                {
                    lock (LockObect) { 
                        log = ObjectBuildFactory<ILog>.Instance(SystemConfiguration.LoggerClassName);
                        if (log != null) { 
                           log.SetObject(obj);
                        }
                    }
                }
                catch
                {
                    log = null;
                }

            }
        }
        public static void Info(string infoText) {
            if (log != null)
            {
                log.Info(infoText);
            }
        }
        public static void Debug(string debugText)
        {
            if (log != null)
            {
                log.Debug(debugText);
            }
        }
        public static void Warn(string warnText)
        {
            if (log != null)
            {
                log.Warn(warnText);
            }
        }
        public static void Error(string errorText, Exception exception)
        {
            if (log != null)
            {
                log.Error(errorText,exception);
            }
        }


    }
}
