﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PINs.GlobalData;
using PINs.Tools;

namespace PINs.Algorithm
{
    /// <summary>
    /// encapsulate RedBlackTree Class, include various implementation of insert,delete...
    /// </summary>
    public class PINRedBlackTree: IBinaryTree<int>
    {
        /// <summary>
        /// .Net SortedSet Object. Only be operated by class self.
        /// </summary>
        private System.Collections.Generic.SortedSet<int> RBTree;

        /// <summary>
        /// ReadOnly Property, for exampel :foreach (var item in Items) 
        /// </summary>
        public System.Collections.Generic.SortedSet<int> Items { get { return RBTree; } }
        /// <summary>
        /// encapsulate log class
        /// </summary>
        /// <param name="text">log content</param>
        private void Info(string text)
        {
            LoggerHelper.Info(text);
        }
        /// <summary>
        /// quantity of nodes
        /// </summary>
        public int Length
        {
            get { return RBTree.Count<int>(); }
        }
        public PINRedBlackTree(ILog log)
        {
            RBTree = new SortedSet<int>();
            
        }
        /// <summary>
        /// Get Node's value by Index
        /// </summary>
        /// <param name="Index">Index start from 1.</param>
        /// <returns>if Index is valid ,return real value otherwise ,return -1</returns>
        public int GetValue(int Index)
        {
            List<int> listSet = RBTree.ToList<int>();
            if (Index <= listSet.Count)
            {
                return listSet[Index - 1];
            }
            return -1;
        }
        /// <summary>
        /// Clear all of nodes
        /// </summary>
        public void Clear()
        {
            RBTree.Clear();
        }
        /// <summary>
        /// add a node(a PIN） to tree
        /// </summary>
        /// <param name="t">PIN</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
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
        /// <summary>
        /// delete a node(a PIN） from tree
        /// </summary>
        /// <param name="t">PIN</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
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
        /// <summary>
        /// Judge RedBlackTree include a PIN
        /// </summary>
        /// <param name="t">PIN</param>
        /// <returns>if PIN is exist return true , if not return false</returns>
        public bool Contains(int t)
        {
            return RBTree.Contains(t);
        }
        /// <summary>
        ///  Save all of nodes to a physical file
        /// </summary>
        /// <param name="FileName">filename which include fullpath</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        public bool SaveToFile(string FileName)
        {
            bool rtn;
            try {
                //overwrite the file
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
        /// <summary>
        /// Load PIN data from a physical file
        /// </summary>
        /// <param name="FileName">filename which include fullpath</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
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
