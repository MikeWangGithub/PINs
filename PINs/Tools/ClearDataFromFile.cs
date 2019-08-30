using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PINs.Tools
{
    public class ClearDataFromFile: IClearData
    {
        private ISet<int> ClearObj;
        public void SetClearObject(ISet<int> obj)
        {
            ClearObj = obj;
        }
        /// <summary>
        /// Delete a physical file 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool Clear(string FileName)
        {
            bool rtn;
            try
            {
                System.IO.File.Delete(FileName);
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

