using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PINs.Tools
{
    public class LoadDataFromFile : ILoadData
    {
        private AlgorithmType objType;
        private Object LoadObj;
        public void SetLoadObject(HashSet<int> obj)
        {
            objType = AlgorithmType.HashSet;
            LoadObj = obj;
        }
        public void SetLoadObject(SortedSet<int> obj)
        {
            objType = AlgorithmType.RedBlackTree;
            LoadObj = obj;
        }
        public bool Load(string FileName)
        {
            bool rtn;
            try
            {
                StreamReader sr = new StreamReader(FileName, Encoding.UTF8);
                string s;
                switch (objType)
                {
                    case AlgorithmType.HashSet:
                        ((HashSet<int>)LoadObj).Clear();
                        break;
                    case AlgorithmType.RedBlackTree:
                        ((SortedSet<int>)LoadObj).Clear();
                        break;
                    default:
                        break;
                }
                
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {

                        int item = System.Convert.ToInt32(s);

                        switch (objType)
                        {
                            case AlgorithmType.HashSet:
                                ((HashSet<int>)LoadObj).Add(item);
                                break;
                            case AlgorithmType.RedBlackTree:
                                ((SortedSet<int>)LoadObj).Add(item);
                                break;
                            default:
                                break;
                        }
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

