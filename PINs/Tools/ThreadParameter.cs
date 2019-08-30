using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace PINs.Tools
{
    public enum PINThreadName { GetNumber = 1, DigitInitial = 2 }
    public class DigitInitialParameter : ICloneable {

        private SafeCallDelegate _RefreshQuantityFunction;
        public SafeCallDelegate RefreshQuantityFunction
        {
            get { return _RefreshQuantityFunction; }
        }
        public void SetRefreshQuantityFunction(SafeCallDelegate value)
        {
            _RefreshQuantityFunction = value;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    //public class ParameterSystem : ICloneable
    //{
    //    private bool _Debug;
    //    public bool Debug
    //    {
    //        get { return _Debug; }
    //    }
    //    private void SetDebug(bool value)
    //    {
    //        _Debug = value;
    //    }

    //    private string _LoggerClassName;
    //    public string LoggerClassName { get { return _LoggerClassName; } }
    //    private void SetLoggerClassName(string value)
    //    {
    //        _LoggerClassName = value;
    //    }

    //    private List<string> _ExceptionNumberRegex;
    //    public List<string> ExceptionNumberRegex { get { return _ExceptionNumberRegex; } }
    //    private void SetExceptionNumberRegex(string ExceptionNumberStr)
    //    {
    //        string RegexStr = ExceptionNumberStr;
    //        if (_ExceptionNumberRegex == null)
    //        {
    //            _ExceptionNumberRegex = new List<string>();
    //        }
    //        _ExceptionNumberRegex = RegexStr.Split('|').ToList<string>();
    //    }

    //    private string _RightNumberRegex;
    //    public string RightNumberRegex { get { return _RightNumberRegex; } }
    //    private void SetRightNumberRegex(string value)
    //    {
    //        _RightNumberRegex = value;
    //    }
    //    private int _MinDigit;
    //    public int MinDigit { get { return _MinDigit; } }
    //    private void SetMinDigit(int value)
    //    {
    //        _MinDigit = value;
    //    }
    //    private int _MaxDigit;
    //    public int MaxDigit { get { return _MaxDigit; } }
    //    private void SetMaxDigit(int value)
    //    {
    //        _MaxDigit = value;
    //    }
    //    private string _ExceptionDigitFileName;
    //    public string ExceptionDigitFileName { get { return _ExceptionDigitFileName; } }
    //    private void SetExceptionDigitFileName(string value)
    //    {
    //        _ExceptionDigitFileName = value;
    //    }
    //    private string _UsedDigitFileName;
    //    public string UsedDigitFileName { get { return _UsedDigitFileName; } }

    //    private void SetUsedDigitFileName(string value)
    //    {
    //        _UsedDigitFileName = value;
    //    }

    //    private string _UnusedDigitFileName;
    //    public string UnusedDigitFileName { get { return _UnusedDigitFileName; } }
    //    private void SetUnusedDigitFileName(string value)
    //    {
    //        _UnusedDigitFileName = value;
    //    }

    //    public string AppPath { get; }
    //    public string ExecutedPath { get; }

    //    private bool _IsNeedNewGeneration;
    //    public bool IsNeedNewGeneration { get { return _IsNeedNewGeneration; } }

    //    private void SetIsNeedNewGeneration(bool value)
    //    {
    //        _IsNeedNewGeneration = value;
    //    }


    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }
    //    public ParameterSystem(string executedPath)
    //    {
    //        ExecutedPath = executedPath;
    //        AppPath = System.IO.Directory.GetCurrentDirectory();
    //        //Set AppPath
    //        //if (System.IO.Directory.Exists(ExecutedPath))
    //        //{
    //        //    AppPath = appPath;
    //        //    if (AppPath.Substring(AppPath.Length - 1, 1) == "\\")
    //        //    {
    //        //        AppPath = AppPath.Substring(0, AppPath.Length - 1);
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    AppPath = "";
    //        //}

    //        Initial();
    //        if ((!IsExistsExceptionDigitFile()) || (!IsExistsUsedDigitFile()) || (!IsExistsUnusedDigitFile()))
    //        {
    //            if (!IsNeedNewGeneration)
    //            {
    //                SaveIsNeedNewGeneration(true); //Need to create 3 files
    //                SetIsNeedNewGeneration(AppConfig.GetAppConfig("IsNeedNewGeneration").Trim().ToLower() == "true" ? true : false);
    //            }
    //        }
    //        else
    //        {
    //            //3 files quantity must be 9999.
    //            // miss check code

    //            if (IsNeedNewGeneration)
    //            {
    //                SaveIsNeedNewGeneration(false); //Need to create 3 files
    //            }
    //        }

    //    }
    //    private void Initial()
    //    {

    //        //Set debug
    //        SetDebug((AppConfig.GetAppConfig("debug").Trim().ToLower() == "true") ? true : false);
    //        //Set logger
    //        SetLoggerClassName(AppConfig.GetAppConfig("Logger"));
    //        //Set 
    //        SetExceptionNumberRegex(AppConfig.GetAppConfig("ExceptionNumber"));
    //        //RightNumber
    //        SetRightNumberRegex(AppConfig.GetAppConfig("RightNumber"));
    //        //MinDigit
    //        try
    //        {
    //            SetMinDigit(System.Convert.ToInt32(AppConfig.GetAppConfig("MinDigit")));
    //        }
    //        catch
    //        {
    //            SetMinDigit(1000);

    //        }
    //        //MaxDigit
    //        try
    //        {
    //            SetMaxDigit(System.Convert.ToInt32(AppConfig.GetAppConfig("MaxDigit")));
    //        }
    //        catch
    //        {
    //            SetMaxDigit(9999);

    //        }
    //        //ExceptionDigitFileName
    //        SetExceptionDigitFileName(AppPath + "\\" + AppConfig.GetAppConfig("ExceptionDigitFileName"));
    //        //UsedDigitFileName
    //        SetUsedDigitFileName(AppPath + "\\" + AppConfig.GetAppConfig("UsedDigitFileName"));
    //        //UnusedDigitFileName
    //        SetUnusedDigitFileName(AppPath + "\\" + AppConfig.GetAppConfig("UnusedDigitFileName"));
    //        //
    //        SetIsNeedNewGeneration(AppConfig.GetAppConfig("IsNeedNewGeneration").Trim().ToLower() == "true" ? true : false);

    //    }
    //    public bool IsExistsExceptionDigitFile()
    //    {
    //        return System.IO.File.Exists(ExceptionDigitFileName);
    //    }
    //    public bool IsExistsUsedDigitFile()
    //    {
    //        return System.IO.File.Exists(UsedDigitFileName);
    //    }
    //    public bool IsExistsUnusedDigitFile()
    //    {
    //        return System.IO.File.Exists(UnusedDigitFileName);
    //    }

    //    public bool SaveIsNeedNewGeneration(bool value)
    //    {
    //        return AppConfig.SaveAppConfig(this.ExecutedPath, "IsNeedNewGeneration", value.ToString());
    //    }
    //}
    
}
