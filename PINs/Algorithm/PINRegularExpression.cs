using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PINs.Algorithm
{
    /// <summary>
    /// Regular Expression 
    /// </summary>
    public class PINRegularExpression
    {
        /// <summary>
        /// Match Source with Regex String
        /// </summary>
        /// <param name="SourceString">SourceString</param>
        /// <param name="RegexString">RegexString</param>
        /// <returns>true ,Source is matched with the Regex; false not matched</returns>
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
        /// <summary>
        /// Match Source with a array of Regex String
        /// </summary>
        /// <param name="SourceString">SourceString</param>
        /// <param name="RegexList">array of Regex String</param>
        /// <returns>true ,Source is matched with one of arary of the Regex; false ,all regex is not matched</returns>
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
        /// <summary>
        /// Judge:Is a number N digit. N kan be 4,5,6....
        /// N is set in App.config.
        /// </summary>
        /// <param name="SourceString">SourceString</param>
        /// <param name="RightFormatString">Regex</param>
        /// <returns>true:number is N digit; false: not N digit</returns>
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
        /// <summary>
        /// Judge: Is a number valid? 
        /// </summary>
        /// <param name="Digit">a PIN</param>
        /// <param name="RightFormatString">Regex</param>
        /// <param name="RegexList">Array of Regex</param>
        /// <returns></returns>
        public static bool IsValidDigit(int Digit, string RightFormatString, List<string> RegexList)
        {
            bool rtn = true;
            if(IsRightFormat(Digit.ToString(), RightFormatString))
            {
                rtn = !IsMatch(Digit.ToString(), RegexList);
            }
            else
            {
                rtn = false;
            }
            return rtn;
        }
    }
}
