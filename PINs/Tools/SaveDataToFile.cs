using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PINs.Tools;

namespace PINs.Tools
{
    /// <summary>
    /// Save data to a physical file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SaveDataToFile<T>:ISaveData<T>
    {
        //private AlgorithmType objType;
        private ISet<T> SaveObj;
        public void SetSaveObject(ISet<T> obj)
        {
            SaveObj = obj;
        }
        /// <summary>
        /// Open a physical file and write digit in the file
        /// Overwrite the file.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool Save(string FileName)
        {
            bool rtn;
            try
            {
                //overwrite the file
                StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8);
                foreach (T item in SaveObj)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
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
