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
    /// <summary>
    /// Thread for initial 3 Set
    /// </summary>
    public class ThreadDigitInitial: PINThread
    {
        //
        private DigitInitialParameter param;
        public ThreadDigitInitial( CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base( _tokenSource, _threadParameter)
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
        /// <summary>
        /// don't need to check anything
        /// </summary>
        /// <returns></returns>
        public override bool CheckParameter()
        {
            
            return true;
        }

        /// <summary>
        /// Execute Initial Function and Refresh quantity on the Mainform.
        /// </summary>
        /// <returns>it is not important</returns>
        public override int RunSubThread()
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            DigitSet.Initial();
            param.RefreshQuantityFunction();
            return 0;
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
        
    }
}
