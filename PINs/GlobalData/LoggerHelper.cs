using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using PINs.GlobalData;

namespace PINs.GlobalData
{
    /// <summary>
    /// Log Tools 
    /// Static Class and Global Class.
    /// Can be used by everyone and anywhere.
    /// </summary>
    public static class LoggerHelper
    {
        /// <summary>
        /// interface log
        /// </summary>
        public static ILog log;
        /// <summary>
        /// Lock object
        /// </summary>
        private static object LockObect = new object();
        /// <summary>
        /// Initial Log instance
        /// By DIP, dynamic create log
        /// </summary>
        /// <param name="obj"></param>
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
        /// <summary>
        /// Print Normal Information 
        /// </summary>
        /// <param name="infoText">message</param>
        public static void Info(string infoText) {
            if (log != null)
            {
                log.Info(infoText);
            }
        }
        /// <summary>
        /// print debug information
        /// </summary>
        /// <param name="debugText">message</param>
        public static void Debug(string debugText)
        {
            if (log != null)
            {
                log.Debug(debugText);
            }
        }
        /// <summary>
        /// Print warn information
        /// </summary>
        /// <param name="warnText">message</param>
        public static void Warn(string warnText)
        {
            if (log != null)
            {
                log.Warn(warnText);
            }
        }
        /// <summary>
        /// Print error
        /// </summary>
        /// <param name="errorText">message</param>
        /// <param name="exception">exception</param>
        public static void Error(string errorText, Exception exception)
        {
            if (log != null)
            {
                log.Error(errorText,exception);
            }
        }
    }
}


