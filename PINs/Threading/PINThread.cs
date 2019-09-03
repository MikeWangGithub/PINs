using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PINs.Tools;

namespace PINs.Threading
{

    /// <summary>
    /// thread abstract class
    /// encapsulate public methods
    /// </summary>
    public abstract class PINThread
    {
        /// <summary>
        /// Control if cancel this thread
        /// </summary>
        protected CancellationTokenSource tokenSource;
        /// <summary>
        /// Control if cancel this thread
        /// Value come from caller.
        /// </summary>
        protected CancellationToken token;
        
        /// <summary>
        /// Return object
        /// </summary>
        protected Task<int> task;
        /// <summary>
        /// Parameter of this thread. can be defined by anyway
        /// </summary>
        protected ICloneable ThreadParameter;


        public PINThread(CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            tokenSource = _tokenSource;
            token = tokenSource.Token;
            ThreadParameter = _threadParameter;
            
        }
        /// <summary>
        /// encapsulate main function in Run.
        /// include, async technique
        /// </summary>
        /// <returns></returns>
        public virtual Task<int> Run()
        {
            task = Task<int>.Run(() => {
                if (!CheckParameter()) return -1;
                DoSomethingBeforeRunSub();
                int rtn = RunSubThread();
                DoSomethingAfterRunSub();
                return rtn;
            });
            return task;
        }
        /// <summary>
        /// do something before mainly function RunSubThread which is implemented in childclass.
        /// </summary>
        public virtual void DoSomethingBeforeRunSub()
        {
            
        }
        /// <summary>
        /// do something after mainly function RunSubThread which is implemented in childclass.
        /// </summary>
        public virtual void DoSomethingAfterRunSub()
        {

        }
        /// <summary>
        /// mainly function what this thread want to do is in this function.
        /// it is needed to be implemented in childclass.
        /// support recursive call
        /// </summary>
        /// <returns></returns>
        public abstract int RunSubThread();
        /// <summary>
        /// Check threadparameter is OK
        /// </summary>
        /// <returns>true : execute RunSubThread ;false: not execute RunSubThread</returns>
        public abstract bool CheckParameter();

        /// <summary>
        /// If this thread is needed to be cancel. Throw an exception.
        /// </summary>
        public void IsTaskCanceled()
        {
            if (token.IsCancellationRequested)
            {
                // Clean up here, then...
                
                // log.LogTaskCancel(this.GetType().Name);
                token.ThrowIfCancellationRequested();
            }
        }
    }


    


    
}
