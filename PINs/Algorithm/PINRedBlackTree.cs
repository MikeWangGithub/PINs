using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PINs.GlobalData;
using PINs.Tools;

namespace PINs.Algorithm
{
    public class PINRedBlackTree: IBinaryTree<int>
    {
        public System.Collections.Generic.SortedSet<int> RBTree;
        
        private void Info(string text)
        {
            LoggerHelper.Info(text);
        }
        public int Length
        {
            get { return RBTree.Count<int>(); }
        }
        public PINRedBlackTree(ILog log)
        {
            RBTree = new SortedSet<int>();
            
        }
        public int GetValue(int Index)
        {
            List<int> listSet = RBTree.ToList<int>();
            if (Index <= listSet.Count)
            {
                return listSet[Index - 1];
            }
            return -1;
        }
        public void Clear()
        {
            RBTree.Clear();
        }
        public bool Insert(int t)
        {
            bool rtn = true;
            try {
                RBTree.Add(t);
            }
            catch (Exception ex)
            {
                rtn = false;
                
            }
            finally
            {
                
            }
            return rtn;
            
        }
        public bool Delete(int t)
        {
            
            bool rtn = true;
            try
            {
                RBTree.Remove(t);
            }
            catch (Exception ex)
            {
                rtn = false;
            }
            finally
            {

            }
            return rtn;
            
        }
        public bool Contains(int t)
        {
            return RBTree.Contains(t);
        }

        public bool SaveToFile(string FileName)
        {
            bool rtn;
            try { 
                StreamWriter sw = new StreamWriter(FileName, false ,Encoding.UTF8);
                foreach (int item in RBTree)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                rtn = true;
            }
            catch(Exception ex)
            {
                rtn = false;
            }
            return rtn;

        }

        public bool OpenFromFile(string FileName)
        {
           
            bool rtn;
            try
            {
                StreamReader sr = new StreamReader(FileName, Encoding.UTF8);
                string s ;
                Clear();
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        int item = System.Convert.ToInt32(s);
                        Insert(item);
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
