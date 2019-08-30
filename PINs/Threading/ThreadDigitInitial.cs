using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;
using PINs.Algorithm;
using PINs.GlobalData;

namespace PINs.Threading
{
    public class ThreadDigitInitial: PINThread
    {
        private DigitInitialParameter param;
        public ThreadDigitInitial(ILog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (DigitInitialParameter)this.ThreadParameter;
            }
            else
            {
                param = null;
            }
        }

        public override bool CheckParameter()
        {
            
            return true;
        }


        public override int RunSubThread()
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            DigitSet.Initial();
            param.RefreshQuantityFunction();
            return 0;
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
        
    }
}
