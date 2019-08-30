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
    public class ThreadGetNumber:PINThread
    {
        public ThreadGetNumber(ILog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            
        }

        public override bool CheckParameter()
        {
            if(!DigitSet.DigitSetStatus)
                DigitSet.Initial();
            return DigitSet.DigitSetStatus;
        }


        public override int RunSubThread()
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            int randIndex = 0;
            int rtn = -1;
            if (DigitSet.UnusedHash.Length > 0) {
                bool flag = false;
                while (flag == false)
                {
                    randIndex = PINs.Algorithm.PINRandom.GetRandomDigit(1, DigitSet.UnusedHash.Length);
                    rtn = DigitSet.UnusedHash.GetValue(randIndex);
                    flag = IsValidDigit(rtn);
                    if (flag)
                    {
                        //valid digit
                        DigitSet.UsedHashInsert(rtn);
                        DigitSet.UnusedHashDelete(rtn);
                        if (DigitSet.UnusedHash.Length <= 0)
                        {
                            break;
                        }
                    }
                    else { 
                        //invalid digit
                        DigitSet.ExceptionHashInsert(rtn);
                        DigitSet.UnusedHashDelete(rtn);
                        if (DigitSet.UnusedHash.Length <= 0)
                        {
                            rtn = -1;
                            break;
                        }
                    }
                    
                }
                //Update File
                DigitSet.UsedHashSaveToFile(SystemConfiguration.UsedDigitFileName);
                DigitSet.UnusedHashSaveToFile(SystemConfiguration.UnusedDigitFileName);
                DigitSet.ExceptionHashSaveToFile(SystemConfiguration.ExceptionDigitFileName);
                
            }
            else
            {
                rtn = -1;
            }
            return rtn;
        }


        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            Debug(this.GetType().ToString() + " threading started.\r\n");


        }
        public override void DoSomethingAfterRunSub()
        {
            base.DoSomethingAfterRunSub();
            Debug(this.GetType().ToString() + " threading finished.\r\n");
        }
        private void Debug(string DebugText)
        {
            if (SystemConfiguration.Debug)
            {
                log.Debug(DebugText);
            }
        }
        private bool IsValidDigit(int t)
        {
            bool rtn = true;
            if (DigitSet.ExceptionHash.Contains(t))
            {
                //invalid data
                rtn = false;

            }
            else { 
                rtn = PINRegularExpression.IsValidDigit(t, SystemConfiguration.RightNumberRegex, SystemConfiguration.ExceptionNumberRegex);
            }
            return rtn;
        }
    }
}
