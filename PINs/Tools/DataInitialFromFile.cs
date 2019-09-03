using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace PINs.Tools
{
    /// <summary>
    /// Initial Class
    /// </summary>
    public class DataInitialFromFile : IDataInitial
    {
        
        private ISet<int> IniticalObj;
        public void SetInitialObject(ISet<int> obj)
        {
            IniticalObj = obj;
        }
        /// <summary>
        /// Judge if data set is created
        /// </summary>
        /// <param name="FileName">a physical fileName</param>
        /// <returns></returns>
        public bool IsInitial(string FileName)
        {
            return System.IO.File.Exists(FileName);
            
        }
    }
}
