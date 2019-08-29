using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.IO;
using PINs.GlobalData;

namespace PINs.Algorithm
{
    public class PINHash:IHash<int>
    {
        private System.Collections.Generic.HashSet<int> hash;
        public System.Collections.Generic.HashSet<int> Items { get { return hash; } }
        private void Info(string text)
        {
            LoggerHelper.Info(text);
        }
        public int Length
        {
            get { return hash.Count<int>(); }
        }
        public PINHash()
        {
            hash = new HashSet<int>();
           
        }
        /// <summary>
        /// Get Node's value by Index
        /// </summary>
        /// <param name="Index">Index start from 1.</param>
        /// <returns></returns>
        public int GetValue(int Index)
        {
            
            List<int> listSet = hash.ToList<int>();
            if (Index <= listSet.Count)
            {
                return listSet[Index - 1];
            }
            return -1;
        }
        public void Clear()
        {
            hash.Clear();
        }
        public bool Insert(int t)
        {
            bool rtn = true;
            try
            {
                hash.Add(t);
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
                hash.Remove(t);
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
            return hash.Contains(t);
        }

        public bool SaveToFile(string FileName)
        {
            bool rtn;
            try
            {
                StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8);
                foreach (int item in hash)
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

        public bool OpenFromFile(string FileName)
        {

            bool rtn;
            try
            {
                StreamReader sr = new StreamReader(FileName, Encoding.UTF8);
                string s;
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
