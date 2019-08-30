using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PINs.Tools;
using PINs.GlobalData;

namespace PINs.Tools
{
    /// <summary>
    /// Load digit data from physical file
    /// </summary>
    public class LoadDataFromFile : ILoadData
    {
        private ISet<int> LoadObj;
        public void SetLoadObject(ISet<int> obj)
        {
            LoadObj = obj;
        }
        /// <summary>
        /// Open a physical file and read string 
        /// Convert string to Integer and insert to DigitSet
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool Load(string FileName)
        {
            bool rtn;
            try
            {
                StreamReader sr = new StreamReader(FileName, Encoding.UTF8);
                string s;
                //Clear preceding digit.
                LoadObj.Clear();
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        int item = System.Convert.ToInt32(s);
                        LoadObj.Add(item);
                    }
                    catch
                    {
                        //Throw away non-digital string
                    }
                }
                sr.Close();
                rtn = true;
            }
            catch (Exception ex)
            {
                rtn = false;
            }
            return rtn;
        }
    }
}

