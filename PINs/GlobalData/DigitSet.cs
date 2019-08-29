using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Algorithm;
using System.IO;

namespace PINs.GlobalData
{
    public static class DigitSet
    {
        private static PINHash _UsedHash;
        private static PINHash _UnusedHash;
        private static PINHash _ExceptionHash;

        public static PINHash UsedHash { get { return _UsedHash; } }
        public static PINHash UnusedHash { get { return _UnusedHash; } }
        public static PINHash ExceptionHash { get { return _ExceptionHash; } }

        private static object LockUsedHash = new object();
        private static object LockUnusedHash = new object();
        private static object LockExceptionHash = new object();

        /// <summary>
        /// Initial 3 PINHash
        /// </summary>
        public static void Initial()
        {
            lock (LockUsedHash)
            {
                if(_UsedHash == null)
                    _UsedHash = new PINHash();
            }
            lock (LockUnusedHash) { 
                if(_UnusedHash == null)
                    _UnusedHash = new PINHash();
            }
            lock (LockExceptionHash) { 
                if (_ExceptionHash == null)
                    _ExceptionHash = new PINHash();
            }

            if (!SystemConfiguration.IsExistsExceptionDigitFile() ||
                !SystemConfiguration.IsExistsUnusedDigitFile() ||
                !SystemConfiguration.IsExistsUsedDigitFile()

                )
            {
                //generated 3 binary tree files
                //......
                LoggerHelper.Info("prepare array ...\r\n");
                int[] UnusedList = new int[SystemConfiguration.MaxDigit - SystemConfiguration.MinDigit + 1];
                for (int i = SystemConfiguration.MinDigit; i <= SystemConfiguration.MaxDigit; i++)
                {
                    lock (LockExceptionHash)
                    {
                        _UnusedHash.Insert(i);
                    }
                }
                
                LoggerHelper.Info("save unused ...\r\n");
                try
                {
                    StreamWriter sw = new StreamWriter(SystemConfiguration.UnusedDigitFileName, false, Encoding.UTF8);
                    foreach (int item in _UnusedHash.Items)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                    //rtn = true;
                }
                catch (Exception ex)
                {
                    //rtn = false;
                }
                LoggerHelper.Info("save exception ...\r\n");
                _ExceptionHash.SaveToFile(SystemConfiguration.ExceptionDigitFileName);
                LoggerHelper.Info("save used ...\r\n");
                _UsedHash.SaveToFile(SystemConfiguration.UsedDigitFileName);

            }
            else {
                LoggerHelper.Info("load excepiton ...\r\n");
                _ExceptionHash.OpenFromFile(SystemConfiguration.ExceptionDigitFileName);
                LoggerHelper.Info("load used ...\r\n");
                _UsedHash.OpenFromFile(SystemConfiguration.UsedDigitFileName);
                LoggerHelper.Info("load unused ...\r\n");
                _UnusedHash.OpenFromFile(SystemConfiguration.UnusedDigitFileName);
                LoggerHelper.Info("DigitSet Initial() is end ...\r\n");
            }
            
        }

        /// <summary>
        /// UsedHash Insert a digit
        /// </summary>
        /// <param name="t">digit</param>
        public static void UsedHashInsert(int t)
        {
            if (UsedHash == null)
                return;
            lock (LockUsedHash)
            {
                UsedHash.Insert(t);
            }
        }

        /// <summary>
        /// UnusedHash Insert a digit
        /// </summary>
        /// <param name="t">digit</param>
        public static void UnusedHashInsert(int t)
        {
            if (UnusedHash == null)
                return;
            lock (LockUnusedHash)
            {
                UnusedHash.Insert(t);
            }
        }

        /// <summary>
        /// ExceptionHash Insert a digit
        /// </summary>
        /// <param name="t">digit</param>
        public static void ExceptionHashInsert(int t)
        {
            if (ExceptionHash == null)
                return;
            lock (LockExceptionHash)
            {
                ExceptionHash.Insert(t);
            }
        }

        /// <summary>
        /// UsedHash delete a digit
        /// </summary>
        /// <param name="t">digit</param>
        public static void UsedHashDelete(int t)
        {
            if (UsedHash == null)
                return;
            lock (LockUsedHash)
            {
                UsedHash.Delete(t);
            }
        }

        /// <summary>
        /// UnusedHash Delete a digit
        /// </summary>
        /// <param name="t">digit</param>
        public static void UnusedHashDelete(int t)
        {
            if (UnusedHash == null)
                return;
            lock (LockUnusedHash)
            {
                UnusedHash.Delete(t);
            }
        }

        /// <summary>
        /// ExceptionHash Delete a digit
        /// </summary>
        /// <param name="t">digit</param>
        public static void ExceptionHashDelete(int t)
        {
            if (ExceptionHash == null)
                return;
            lock (LockExceptionHash)
            {
                ExceptionHash.Delete(t);
            }
        }


        /// <summary>
        /// UsedHash Save data to a file
        /// </summary>
        /// <param name="t">digit</param>
        public static void UsedHashSaveToFile(string FileName)
        {
            if (UsedHash == null)
                return;
            lock (LockUsedHash)
            {
                UsedHash.SaveToFile(FileName);
            }
        }

        /// <summary>
        /// UnusedHash Save data to a file
        /// </summary>
        /// <param name="t">digit</param>
        public static void UnusedHashSaveToFile(string FileName)
        {
            if (UnusedHash == null)
                return;
            lock (LockUnusedHash)
            {
                UnusedHash.SaveToFile(FileName);
            }
        }

        /// <summary>
        /// ExceptionHash  Save data to a file
        /// </summary>
        /// <param name="t">digit</param>
        public static void ExceptionHashSaveToFile(string FileName)
        {
            if (ExceptionHash == null)
                return;
            lock (LockExceptionHash)
            {
                ExceptionHash.SaveToFile(FileName);
            }
        }


        /// <summary>
        /// UsedHash open data from a file
        /// </summary>
        /// <param name="t">digit</param>
        public static void UsedHashOpenFromFile(string FileName)
        {
            if (UsedHash == null)
                return;
            lock (LockUsedHash)
            {
                UsedHash.OpenFromFile(FileName);
            }
        }

        /// <summary>
        /// UnusedHash open data from a file
        /// </summary>
        /// <param name="t">digit</param>
        public static void UnusedHashOpenFromFile(string FileName)
        {
            if (UnusedHash == null)
                return;
            lock (LockUnusedHash)
            {
                UnusedHash.OpenFromFile(FileName);
            }
        }

        /// <summary>
        /// ExceptionHash  open data from a file
        /// </summary>
        /// <param name="t">digit</param>
        public static void ExceptionHashOpenFromFile(string FileName)
        {
            if (ExceptionHash == null)
                return;
            lock (LockExceptionHash)
            {
                ExceptionHash.OpenFromFile(FileName);
            }
        }

    }
}
