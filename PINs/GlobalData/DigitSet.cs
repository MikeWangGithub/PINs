using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Algorithm;
using System.IO;
using System.Collections.Generic;
using PINs.Tools;


namespace PINs.GlobalData
{
    /// <summary>
    /// Manage 3 Digit Set
    /// </summary>
    public static class DigitSet
    {
        /// <summary>
        /// The Set of used PINs
        /// </summary>
        private static PINs.Algorithm.ISet<int> _UsedSet;
        /// <summary>
        /// Set of unused PINs
        /// </summary>
        private static PINs.Algorithm.ISet<int> _UnusedSet;
        /// <summary>
        /// Set of Exception PINs
        /// </summary>
        private static PINs.Algorithm.ISet<int> _ExceptionSet;
        /// <summary>
        /// Record if _UsedSet has been initial. true : initial ; false: not initial
        /// </summary>
        private static bool UsedSetStatus;
        /// <summary>
        /// Record if _UnusedSet has been initial. true : initial ; false: not initial
        /// </summary>
        private static bool UnusedSetStatus;
        /// <summary>
        /// Record if _ExceptionSet has been initial. true : initial ; false: not initial
        /// </summary>
        private static bool ExceptionSetStatus;

        /// <summary>
        /// All Sets' Status
        /// </summary>
        public static bool DigitSetStatus
        {
            get
            {
                if (UsedSetStatus && UnusedSetStatus && ExceptionSetStatus)
                    return true;
                else
                    return false;
            }
        }

        static DigitSet()
        {
            UsedSetStatus = false;
            UnusedSetStatus = false;
            ExceptionSetStatus = false;
        }
        /// <summary>
        /// Used digit Set. ReadOnly
        /// </summary>
        public static PINs.Algorithm.ISet<int> UsedSet { get { return _UsedSet; } }
        /// <summary>
        /// Unused digit Set. ReadOnly
        /// </summary>
        public static PINs.Algorithm.ISet<int> UnusedSet { get { return _UnusedSet; } }
        /// <summary>
        /// Exception digit Set. ReadOnly
        /// </summary>
        public static PINs.Algorithm.ISet<int> ExceptionSet { get { return _ExceptionSet; } }
        /// <summary>
        /// Lock object - UsedSet
        /// </summary>
        private static object LockUsedSet = new object();
        /// <summary>
        /// Lock object - UnusedSet
        /// </summary>
        private static object LockUnusedSet = new object();
        /// <summary>
        /// Lock object - ExceptionSet
        /// </summary>
        private static object LockExceptionSet = new object();

        /// <summary>
        /// Initial again when all of the digits have been used.
        /// </summary>
        public static void SetReInitial()
        {
            // Set 3 status to false
            lock (LockUnusedSet)
            {
                UnusedSetStatus = false;
            }
            lock (LockUsedSet)
            {
                UsedSetStatus = false;
            }
            lock (LockExceptionSet)
            {
                ExceptionSetStatus = false;
            }
            // Clear nodes of 3 Sets 
            lock (LockUsedSet)
            {
                if (_UsedSet == null)
                    _UsedSet = ObjectBuildFactory<PINs.Algorithm.ISet<int>>.Instance(SystemConfiguration.AlgorithmClassName);
                else
                    _UsedSet.Clear(SystemConfiguration.UsedDigitDataSet);
            }
            lock (LockUnusedSet)
            {
                if (_UnusedSet == null)
                    _UnusedSet = ObjectBuildFactory<PINs.Algorithm.ISet<int>>.Instance(SystemConfiguration.AlgorithmClassName);
                else
                    _UnusedSet.Clear(SystemConfiguration.UnusedDigitDataSet);
            }
            lock (LockExceptionSet)
            {
                if (_ExceptionSet == null)
                    _ExceptionSet = ObjectBuildFactory<PINs.Algorithm.ISet<int>>.Instance(SystemConfiguration.AlgorithmClassName);
                else
                    _ExceptionSet.Clear(SystemConfiguration.ExceptionDigitDataSet);
            }
        }
        /// <summary>
        /// Initial 3 Set
        /// </summary>
        public static void Initial()
        {
            //create 3 Set Objects by DIP,dynamic create class 
            lock (LockUsedSet)
            {
                if (_UsedSet == null)
                    _UsedSet = ObjectBuildFactory<PINs.Algorithm.ISet<int>>.Instance(SystemConfiguration.AlgorithmClassName);
            }
            lock (LockUnusedSet)
            {
                if (_UnusedSet == null)
                    _UnusedSet = ObjectBuildFactory<PINs.Algorithm.ISet<int>>.Instance(SystemConfiguration.AlgorithmClassName);
            }
            lock (LockExceptionSet)
            {
                if (_ExceptionSet == null)
                    _ExceptionSet = ObjectBuildFactory<PINs.Algorithm.ISet<int>>.Instance(SystemConfiguration.AlgorithmClassName);
            }
            //Juage: if 1st execute this program
            if (!_UnusedSet.IsInitial(SystemConfiguration.UnusedDigitDataSet) ||
                !_UsedSet.IsInitial(SystemConfiguration.UsedDigitDataSet) ||
                !_ExceptionSet.IsInitial(SystemConfiguration.ExceptionDigitDataSet) 

                )
            {
                //1st time execute this program
                //generated 3 Set
                //......
                Debug("prepare unused set ...\r\n");
                for (int i = SystemConfiguration.MinDigit; i <= SystemConfiguration.MaxDigit; i++)
                {
                    lock (LockExceptionSet)
                    {
                        _UnusedSet.Insert(i);
                    }
                }
                Debug("Unused set is OK ...\r\n");
                lock (LockUnusedSet)
                {
                    UnusedSetStatus = true;
                }
                lock (LockUsedSet)
                {
                    UsedSetStatus = true;  //UsedSet contains 0 data.
                }
                lock (LockExceptionSet)
                {
                    ExceptionSetStatus = true; //ExceptionSet contains 0 data.
                }
                Debug("All of digit Set is OK ...\r\n");
                LoggerHelper.Info("Digits' Set is prepared.\r\n");

                //Save node to somewhere, now they are physical files.
                _UnusedSet.Save(SystemConfiguration.UnusedDigitDataSet);
                Debug("Unused set is saved  to file...\r\n");
                _ExceptionSet.Save(SystemConfiguration.ExceptionDigitDataSet);
                Debug("exception set is saved to file...\r\n");
                _UsedSet.Save(SystemConfiguration.UsedDigitDataSet);
                Debug("used set is saved to file...\r\n");

            }
            else
            {
                //not first execute this program
                if ((UsedSetStatus == false) && (UnusedSetStatus == false) && (ExceptionSetStatus == false))
                {
                    //not initial
                    //Load data to 3 Set from somewhere ,now they are physical files.
                    _ExceptionSet.Load(SystemConfiguration.ExceptionDigitDataSet);
                    lock (LockExceptionSet)
                    {
                        ExceptionSetStatus = true;
                    }
                    Debug("excepiton set is loaded ...\r\n");

                    _UsedSet.Load(SystemConfiguration.UsedDigitDataSet);
                    lock (LockUsedSet)
                    {
                        UsedSetStatus = true;
                    }
                    Debug("used set is loaded ...\r\n");

                    _UnusedSet.Load(SystemConfiguration.UnusedDigitDataSet);
                    lock (LockUnusedSet)
                    {
                        UnusedSetStatus = true;
                    }
                    Debug("unused set id loaded ...\r\n");
                }

            }

        }

        /// <summary>
        /// encapsulate logger function
        /// </summary>
        /// <param name="DebugText"></param>
        private static void Debug(string DebugText)
        {
            if (SystemConfiguration.Debug)
            {
                LoggerHelper.Debug(DebugText);
            }
        }
    }
}
