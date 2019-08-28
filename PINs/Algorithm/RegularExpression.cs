using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PINs.Algorithm
{
    public class RegularExpression
    {
        public static bool IsMatch(string SourceString , string RegexString)
        {
            bool rtn = false;
            Regex regex = new Regex(RegexString);
            if (regex.IsMatch(SourceString))
            {
                rtn = true;
            }
            return rtn;
        }
        public static bool IsMatch(string SourceString, List<string> RegexList)
        {
            bool rtn = false;
            foreach(string RegexStr in RegexList)
            {
                rtn = rtn || IsMatch(SourceString, RegexStr);
                if (rtn) { return rtn; }
            }
            return rtn;
        }
        public static bool IsRightFormat(string SourceString,string RightFormatString)
        {
            bool rtn = false;
            Regex regex = new Regex(RightFormatString);
            if (regex.IsMatch(SourceString))
            {
                rtn = true;
            }
            return rtn;
        }
    }
}
