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

        private static bool UsedHashStatus;
        private static bool UnusedHashStatus;
        private static bool ExceptionHashtatus;

        public static bool DigitSetStatus
        {
            get
            {
                if (UsedHashStatus && UnusedHashStatus && ExceptionHashtatus)
                    return true;
                else
                    return false;
            }
        }

        static DigitSet()
        {
            UsedHashStatus = false;
            UnusedHashStatus = false;
            ExceptionHashtatus = false;
        }
        public static PINHash UsedHash { get { return _UsedHash; } }
        public static PINHash UnusedHash { get { return _UnusedHash; } }
        public static PINHash ExceptionHash { get { return _ExceptionHash; } }

        private static object LockUsedHash = new object();
        private static object LockUnusedHash = new object();
        private static object LockExceptionHash = new object();
        private static object LockDigitSetStatus = new object();

        public static void SetReInitial()
        {
            lock (LockUnusedHash)
            {
                UnusedHashStatus = false;
            }
            lock (LockUsedHash)
            {
                UsedHashStatus = false;  
            }
            lock (LockExceptionHash)
            {
                ExceptionHashtatus = false; 
            }
            lock (LockUsedHash)
            {
                if (_UsedHash == null)
                    _UsedHash = new PINHash();
                else
                    _UsedHash.Clear();
            }
            lock (LockUnusedHash)
            {
                if (_UnusedHash == null)
                    _UnusedHash = new PINHash();
                else
                    _UnusedHash.Clear();
            }
            lock (LockExceptionHash)
            {
                if (_ExceptionHash == null)
                    _ExceptionHash = new PINHash();
                else
                    _ExceptionHash.Clear();
            }
        }
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
                Debug("prepare unused set ...\r\n");
                for (int i = SystemConfiguration.MinDigit; i <= SystemConfiguration.MaxDigit; i++)
                {
                    lock (LockExceptionHash)
                    {
                        _UnusedHash.Insert(i);
                    }
                }
                Debug("Unused set is OK ...\r\n");
                lock (LockUnusedHash)
                {
                    UnusedHashStatus = true;
                }
                lock (LockUsedHash) { 
                    UsedHashStatus = true;  //UsedHash contains 0 data.
                }
                lock (LockExceptionHash)
                {
                    ExceptionHashtatus = true; //ExceptionHash contains 0 data.
                }
                Debug("All of digit Set is OK ...\r\n");
                LoggerHelper.Info("Digit Set is prepared.\r\n");

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
                Debug("Unused set is saved  to file...\r\n");
                _ExceptionHash.SaveToFile(SystemConfiguration.ExceptionDigitFileName);
                Debug("exception set is saved to file...\r\n");
                _UsedHash.SaveToFile(SystemConfiguration.UsedDigitFileName);
                Debug("used set is saved to file...\r\n");

            }
            else {
                if((UsedHashStatus==false) && (UnusedHashStatus==false) && (ExceptionHashtatus == false)) { 
                    _ExceptionHash.OpenFromFile(SystemConfiguration.ExceptionDigitFileName);
                    lock (LockExceptionHash)
                    {
                        ExceptionHashtatus = true; 
                    }
                    Debug("excepiton set is loaded ...\r\n");

                    _UsedHash.OpenFromFile(SystemConfiguration.UsedDigitFileName);
                    lock (LockUsedHash)
                    {
                        UsedHashStatus = true;  
                    }
                    Debug("used set is loaded ...\r\n");

                    _UnusedHash.OpenFromFile(SystemConfiguration.UnusedDigitFileName);
                    lock (LockUnusedHash)
                    {
                        UnusedHashStatus = true;
                    }
                    Debug("unused set id loaded ...\r\n");
                }

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

        private static void Debug(string DebugText)
        {
            if (SystemConfiguration.Debug)
            {
                LoggerHelper.Debug(DebugText);
            }
        }
    }
}
