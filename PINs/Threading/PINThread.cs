using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PINs.Tools;

namespace PINs.Threading
{
  

    public abstract class PINThread
    {
        protected CancellationTokenSource tokenSource;
        protected CancellationToken token;
        protected ILog log;
        protected Task<int> task;
        protected ICloneable ThreadParameter;
        // protected string reflectionName;

        public PINThread(ILog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            tokenSource = _tokenSource;
            token = tokenSource.Token;
            log = _log;
            ThreadParameter = _threadParameter;
            
        }

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
        public virtual void DoSomethingBeforeRunSub()
        {
            
        }
        public virtual void DoSomethingAfterRunSub()
        {

        }
        public abstract int RunSubThread();
        public abstract bool CheckParameter();
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
