using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PINs.Tools;

namespace PINs.Tools
{
    public class SaveDataToFile<T>:ISaveData<T>
    {
        private AlgorithmType objType;
        private Object SaveObj;
        public void SetSaveObject(HashSet<T> obj)
        {
            objType = AlgorithmType.HashSet;
            SaveObj = obj;
        }
        public void SetSaveObject(SortedSet<T> obj)
        {
            objType = AlgorithmType.RedBlackTree;
            SaveObj = obj;
        }
        public bool Save(string FileName)
        {
            bool rtn;
            try
            {
                //overwrite the file
                StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8);
                switch (objType)
                {
                    case AlgorithmType.HashSet:
                        foreach (T item in (HashSet<T>)SaveObj)
                        {
                            sw.WriteLine(item);
                        }
                        break;
                    case AlgorithmType.RedBlackTree:
                        foreach (T item in (SortedSet<T>)SaveObj)
                        {
                            sw.WriteLine(item);
                        }
                        break;
                    default:
                        break;
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
