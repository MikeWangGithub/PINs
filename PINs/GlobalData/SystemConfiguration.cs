using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;

namespace PINs.GlobalData
{
    /// <summary>
    /// System Configuration .
    /// All properties come from App.config
    /// Global Class. Can be used by everyone and anywhere.
    /// </summary>
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

        private static string _SaveDataClassName;
        public static string SaveDataClassName { get { return _SaveDataClassName; } }
        private static void SetSaveDataClassName(string value)
        {
            _SaveDataClassName = value;
        }

        private static string _LoadDataClassName;
        public static string LoadDataClassName { get { return _LoadDataClassName; } }
        private static void SetLoadDataClassName(string value)
        {
            _LoadDataClassName = value;
        }

        private static string _ClearDataClassName;
        public static string ClearDataClassName { get { return _ClearDataClassName; } }
        private static void SetClearDataClassName(string value)
        {
            _ClearDataClassName = value;
        }

        private static string _DataInitialClass;
        public static string DataInitialClass  { get { return _DataInitialClass; } }
        private static void SetDataInitialClassName(string value)
        {
            _DataInitialClass = value;
        }

        private static string _AlgorithmClassName;
        public static string AlgorithmClassName { get { return _AlgorithmClassName; } }
        private static void SetAlgorithmClassName(string value)
        {
            _AlgorithmClassName = value;
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
        private static  string _ExceptionDigitDataSet;
        public static  string ExceptionDigitDataSet { get { return _ExceptionDigitDataSet; } }
        private static void SetExceptionDigitDataSet(string value)
        {
            _ExceptionDigitDataSet = value;
        }
        private static string _UsedDigitDataSet;
        public static string UsedDigitDataSet { get { return _UsedDigitDataSet; } }

        private static void SetUsedDigitDataSet(string value)
        {
            _UsedDigitDataSet = value;
        }

        private static  string _UnusedDigitDataSet;
        public static string UnusedDigitDataSet { get { return _UnusedDigitDataSet; } }
        private static void SetUnusedDigitDataSet(string value)
        {
            _UnusedDigitDataSet = value;
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
            

        }
        private static void LoadConfiguraion()
        {

            //Set debug
            SetDebug((AppConfig.GetAppConfig("debug").Trim().ToLower() == "true") ? true : false);
            //Set logger
            SetLoggerClassName(AppConfig.GetAppConfig("Logger"));
            //Set 
            SetSaveDataClassName(AppConfig.GetAppConfig("SaveDataClass"));
            //Set 
            SetLoadDataClassName(AppConfig.GetAppConfig("LoadDataClass"));
            //Set 
            SetClearDataClassName(AppConfig.GetAppConfig("ClearDataClass"));
            //Set 
            SetDataInitialClassName(AppConfig.GetAppConfig("DataInitialClass"));
            //Set 
            SetAlgorithmClassName(AppConfig.GetAppConfig("AlgorithmClass"));
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
            //ExceptionDigitDataSet
            SetExceptionDigitDataSet(AppPath + "\\" + AppConfig.GetAppConfig("ExceptionDigitDataSet"));
            //UsedDigitDataSet
            SetUsedDigitDataSet(AppPath + "\\" + AppConfig.GetAppConfig("UsedDigitDataSet"));
            //UnusedDigitDataSet
            SetUnusedDigitDataSet(AppPath + "\\" + AppConfig.GetAppConfig("UnusedDigitDataSet"));
            //
            SetIsNeedNewGeneration(AppConfig.GetAppConfig("IsNeedNewGeneration").Trim().ToLower() == "true" ? true : false);

        }


        public static bool SaveIsNeedNewGeneration(bool value)
        {
            return AppConfig.SaveAppConfig(ExecutedPath, "IsNeedNewGeneration", value.ToString());
        }
    }
}
