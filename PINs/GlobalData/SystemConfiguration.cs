using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;

namespace PINs.GlobalData
{
    public static class SystemConfiguration
    {
        private static bool _Debug;
        public static bool Debug
        {
            get { return _Debug; }
        }
        private static void SetDebug(bool value)
        {
            _Debug = value;
        }

        private static string _LoggerClassName;
        public static string LoggerClassName { get { return _LoggerClassName; } }
        private static void SetLoggerClassName(string value)
        {
            _LoggerClassName = value;
        }

        private static List<string> _ExceptionNumberRegex;
        public static List<string> ExceptionNumberRegex { get { return _ExceptionNumberRegex; } }
        private static void SetExceptionNumberRegex(string ExceptionNumberStr)
        {
            string RegexStr = ExceptionNumberStr;
            if (_ExceptionNumberRegex == null)
            {
                _ExceptionNumberRegex = new List<string>();
            }
            _ExceptionNumberRegex = RegexStr.Split('|').ToList<string>();
        }

        private static  string _RightNumberRegex;
        public static string RightNumberRegex { get { return _RightNumberRegex; } }
        private static void SetRightNumberRegex(string value)
        {
            _RightNumberRegex = value;
        }
        private static int _MinDigit;
        public static int MinDigit { get { return _MinDigit; } }
        private static void SetMinDigit(int value)
        {
            _MinDigit = value;
        }
        private static int _MaxDigit;
        public static int MaxDigit { get { return _MaxDigit; } }
        private static void SetMaxDigit(int value)
        {
            _MaxDigit = value;
        }
        private static  string _ExceptionDigitFileName;
        public static  string ExceptionDigitFileName { get { return _ExceptionDigitFileName; } }
        private static void SetExceptionDigitFileName(string value)
        {
            _ExceptionDigitFileName = value;
        }
        private static string _UsedDigitFileName;
        public static string UsedDigitFileName { get { return _UsedDigitFileName; } }

        private static void SetUsedDigitFileName(string value)
        {
            _UsedDigitFileName = value;
        }

        private static  string _UnusedDigitFileName;
        public static string UnusedDigitFileName { get { return _UnusedDigitFileName; } }
        private static void SetUnusedDigitFileName(string value)
        {
            _UnusedDigitFileName = value;
        }

        private static string _AppPath;
        public static string AppPath { get { return _AppPath; } }
        private static void SetAppPath(string value)
        {
            _AppPath = value;
        }

        private static string _ExecutedPath;
        public static string ExecutedPath { get { return _ExecutedPath; } }
        private static void SetExecutedPath(string value)
        {
            _ExecutedPath = value;
        }
        private static bool _IsNeedNewGeneration;
        public static bool IsNeedNewGeneration { get { return _IsNeedNewGeneration; } }

        private static void SetIsNeedNewGeneration(bool value)
        {
            _IsNeedNewGeneration = value;
        }


        
        public static void Initial(string executedPath)
        {
            SetExecutedPath(executedPath);
            SetAppPath(System.IO.Directory.GetCurrentDirectory());
        
            LoadConfiguraion();
            if ((!IsExistsExceptionDigitFile()) || (!IsExistsUsedDigitFile()) || (!IsExistsUnusedDigitFile()))
            {
                if (!IsNeedNewGeneration)
                {
                    SaveIsNeedNewGeneration(true); //Need to create 3 files
                    SetIsNeedNewGeneration(AppConfig.GetAppConfig("IsNeedNewGeneration").Trim().ToLower() == "true" ? true : false);
                }
            }
            else
            {
                //3 files quantity must be 9999.
                // miss check code

                if (IsNeedNewGeneration)
                {
                    SaveIsNeedNewGeneration(false); //Need to create 3 files
                }
            }

        }
        private static void LoadConfiguraion()
        {

            //Set debug
            SetDebug((AppConfig.GetAppConfig("debug").Trim().ToLower() == "true") ? true : false);
            //Set logger
            SetLoggerClassName(AppConfig.GetAppConfig("Logger"));
            //Set 
            SetExceptionNumberRegex(AppConfig.GetAppConfig("ExceptionNumber"));
            //RightNumber
            SetRightNumberRegex(AppConfig.GetAppConfig("RightNumber"));
            //MinDigit
            try
            {
                SetMinDigit(System.Convert.ToInt32(AppConfig.GetAppConfig("MinDigit")));
            }
            catch
            {
                SetMinDigit(1000);

            }
            //MaxDigit
            try
            {
                SetMaxDigit(System.Convert.ToInt32(AppConfig.GetAppConfig("MaxDigit")));
            }
            catch
            {
                SetMaxDigit(9999);

            }
            //ExceptionDigitFileName
            SetExceptionDigitFileName(AppPath + "\\" + AppConfig.GetAppConfig("ExceptionDigitFileName"));
            //UsedDigitFileName
            SetUsedDigitFileName(AppPath + "\\" + AppConfig.GetAppConfig("UsedDigitFileName"));
            //UnusedDigitFileName
            SetUnusedDigitFileName(AppPath + "\\" + AppConfig.GetAppConfig("UnusedDigitFileName"));
            //
            SetIsNeedNewGeneration(AppConfig.GetAppConfig("IsNeedNewGeneration").Trim().ToLower() == "true" ? true : false);

        }
        public static bool IsExistsExceptionDigitFile()
        {
            return System.IO.File.Exists(ExceptionDigitFileName);
        }
        public static bool IsExistsUsedDigitFile()
        {
            return System.IO.File.Exists(UsedDigitFileName);
        }
        public static  bool IsExistsUnusedDigitFile()
        {
            return System.IO.File.Exists(UnusedDigitFileName);
        }

        public static bool SaveIsNeedNewGeneration(bool value)
        {
            return AppConfig.SaveAppConfig(ExecutedPath, "IsNeedNewGeneration", value.ToString());
        }
    }
}
