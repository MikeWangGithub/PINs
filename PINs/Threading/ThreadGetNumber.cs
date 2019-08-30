using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;
using PINs.Algorithm;
using PINs.GlobalData;

namespace PINs.Threading
{
    /// <summary>
    /// Thread for get a new PIN.
    /// </summary>
    public class ThreadGetNumber:PINThread
    {
        public ThreadGetNumber(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            
        }
        /// <summary>
        /// DigitSet must be initial first.
        /// </summary>
        /// <returns>initial is successful or not</returns>
        public override bool CheckParameter()
        {
            if(!DigitSet.DigitSetStatus)
                DigitSet.Initial();
            return DigitSet.DigitSetStatus;
        }

        //Get a new PIN
        public override int RunSubThread()
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            int randIndex = 0;
            int rtn = -1;
            if (DigitSet.UnusedSet.Length > 0) {
                //UnusedSet is not null. 

                bool flag = false;
                while (flag == false)
                {
                    // get random index in UnusedSet
                    randIndex = PINs.Algorithm.PINRandom.GetRandomDigit(1, DigitSet.UnusedSet.Length);
                    // Get integer by index in UnusedSet
                    rtn = DigitSet.UnusedSet.GetValue(randIndex);
                    // judge integer is valid
                    flag = IsValidDigit(rtn);
                    if (flag)
                    {
                        //valid digit
                        //Insert digit in UsedSet
                        DigitSet.UsedSet.Insert(rtn);
                        //Delete digit from UnusedSet
                        DigitSet.UnusedSet.Delete(rtn);
                        //judge if it is the last digit
                        if (DigitSet.UnusedSet.Length <= 0)
                        {
                            //it it the last digit
                            break;
                        }
                    }
                    else { 
                        //invalid digit
                        //Insert digit in ExceptionSet
                        DigitSet.ExceptionSet.Insert(rtn);
                        //Delete digit from UnusedSet
                        DigitSet.UnusedSet.Delete(rtn);
                        //judge if it is the last digit
                        if (DigitSet.UnusedSet.Length <= 0)
                        {
                            //it it the last digit
                            rtn = -1;
                            break;
                        }
                    }
                    
                }
                //Save node to somewhere
                DigitSet.UsedSet.Save(SystemConfiguration.UsedDigitFileName);
                DigitSet.UnusedSet.Save(SystemConfiguration.UnusedDigitFileName);
                DigitSet.ExceptionSet.Save(SystemConfiguration.ExceptionDigitFileName);
                
            }
            else
            {
                //UnusedSet is not null. 
                //All of the digits have been used.
                rtn = -1;
            }
            return rtn;
        }

        /// <summary>
        /// print log
        /// </summary>
        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            Debug(this.GetType().ToString() + " threading started.\r\n");


        }
        /// <summary>
        /// print log
        /// </summary>
        public override void DoSomethingAfterRunSub()
        {
            base.DoSomethingAfterRunSub();
            Debug(this.GetType().ToString() + " threading finished.\r\n");
        }
        /// <summary>
        /// encapsulate Log.debug
        /// </summary>
        /// <param name="DebugText"></param>
        private void Debug(string DebugText)
        {
            if (SystemConfiguration.Debug)
            {
                LoggerHelper.Debug(DebugText);
            }
        }
        /// <summary>
        /// judge if a digit is valid
        /// </summary>
        /// <param name="t"></param>
        /// <returns>true: valid; false:invalid</returns>
        private bool IsValidDigit(int t)
        {
            bool rtn = true;
            //used exceptionSet to know if a digit is invalid
            if (DigitSet.ExceptionSet.Contains(t))
            {
                //invalid data
                rtn = false;

            }
            else { 
                //used Regular Expression to check if a digit is invalid
                rtn = PINRegularExpression.IsValidDigit(t, SystemConfiguration.RightNumberRegex, SystemConfiguration.ExceptionNumberRegex);
            }
            return rtn;
        }
    }
}
