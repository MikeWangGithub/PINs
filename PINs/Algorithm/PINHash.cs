﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.IO;
using PINs.GlobalData;

namespace PINs.Algorithm
{
    /// <summary>
    /// Hash Class, include various implementation of insert,delete...
    /// </summary>
    public class PINHash : PINs.Algorithm.ISet<int>
    {
        /// <summary>
        /// Lock object .
        /// if MultiThread use the sam resource ,use lock object for keep right result.
        /// </summary>
        private object Lockobject = new object();
        private ISaveData<int> SaveObject;
        private ILoadData LoadObject;
        private IClearData ClearObject;
        private IDataInitial InitialObject;

        /// <summary>
        /// .Net HashSet Object. Only be operated by class self.
        /// </summary>
        private System.Collections.Generic.HashSet<int> hash;
        /// <summary>
        /// ReadOnly Property, for exampel :foreach (var item in Items) 
        /// </summary>
        public IEnumerable<int> Items { get { return hash; } }
        /// <summary>
        /// encapsulate log class
        /// </summary>
        /// <param name="text">log content</param>
        private void Info(string text)
        {
            LoggerHelper.Info(text);
        }
        public PINHash()
        {
            hash = new HashSet<int>();

        }
        /// <summary>
        /// quantity of nodes
        /// </summary>
        public int Length
        {
            get { return hash.Count<int>(); }
        }
        /// <summary>
        /// Get Node's value by Index
        /// </summary>
        /// <param name="Index">Index start from 1.</param>
        /// <returns>if Index is valid ,return real value otherwise ,return -1</returns>
        public int GetValue(int Index)
        {

            List<int> listSet = hash.ToList<int>();
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
            hash.Clear();
        }
        /// <summary>
        /// add a node(a PIN） to HashSet
        /// </summary>
        /// <param name="t">PIN</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
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
        /// <summary>
        /// delete a node(a PIN） from HashSet
        /// </summary>
        /// <param name="t">PIN</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
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
        /// <summary>
        /// Judge HashSet include a PIN
        /// </summary>
        /// <param name="t">PIN</param>
        /// <returns>if PIN is exist return true , if not return false</returns>
        public bool Contains(int t)
        {
            return hash.Contains(t);
        }
        /// <summary>
        /// Save all of nodes to a physical file/Database/.....
        /// </summary>
        /// <param name="FileName">filename which include fullpath/DataBase connection /......</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        public bool Save(string FileName)
        {
            lock (Lockobject)
            {
                SaveObject = ObjectBuildFactory<ISaveData<int>>.Instance(SystemConfiguration.SaveDataClassName);
                if (SaveObject != null)
                    SaveObject.SetSaveObject(hash);
            }
            if (SaveObject != null)
                return SaveObject.Save(FileName);
            else
                return false;

        }
        /// <summary>
        /// Load PIN data from a physical file/Database/.....
        /// </summary>
        /// <param name="FileName">filename which include fullpath/DataBase connection /......</param>
        /// <returns>Operation is sucessful,return true otherwise false</returns>
        public bool Load(string FileName)
        {
            lock (Lockobject)
            {
                LoadObject = ObjectBuildFactory<ILoadData>.Instance(SystemConfiguration.LoadDataClassName);
                if (LoadObject != null)
                    LoadObject.SetLoadObject(hash);
            }
            if (LoadObject != null)
                return LoadObject.Load(FileName);
            else
                return false;


        }
        /// <summary>
        /// Clear all digits
        /// </summary>
        /// <param name="FileName">filename which include fullpath/DataBase connection /......</param>
        public void Clear(string FileName)
        {
            Clear();
            lock (Lockobject)
            {
                ClearObject = ObjectBuildFactory<IClearData>.Instance(SystemConfiguration.ClearDataClassName);
                if (ClearObject != null)
                    ClearObject.SetClearObject(hash);
            }
            if (ClearObject != null)
            {
                ClearObject.Clear(FileName);
            }
        }
        /// <summary>
        /// Judage if data initial.
        /// </summary>
        /// <param name="FileName">filename which include fullpath/DataBase connection /......</param>
        public bool IsInitial(string FileName)
        {
            lock (Lockobject)
            {
                InitialObject = ObjectBuildFactory<IDataInitial>.Instance(SystemConfiguration.DataInitialClass);
                if (InitialObject != null)
                    InitialObject.SetInitialObject(hash);
            }
            if (InitialObject != null)
            {
                return InitialObject.IsInitial(FileName);
            }
            else
            {
                return false;
            }
        }
    }
}
