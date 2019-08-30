using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;

namespace PINs.Threading
{
    /// <summary>
    /// Thread Context Class
    /// Hide ThreadFactory and all of the concrete ThreadClass
    /// </summary>
    public class ThreadContext
    {
        /// <summary>
        /// Thread object
        /// </summary>
        private PINThread superThread = null;
        /// <summary>
        /// Create conrete thread by ThreadFactory
        /// </summary>
        /// <param name="ThreadName"></param>
        /// <param name="_tokenSource"></param>
        /// <param name="_threadParameter"></param>
        public ThreadContext(PINThreadName ThreadName,
                             CancellationTokenSource _tokenSource,
                             ICloneable _threadParameter)
        {
            superThread = ThreadFactory.createThread(ThreadName,
                                                     _tokenSource,
                                                     _threadParameter);
        }
        /// <summary>
        /// Execute Concrete Class
        /// </summary>
        /// <returns></returns>
        public Task<int> ThreadRun()
        {
            if (superThread != null)
            {
                return superThread.Run();
            }
            else { return null; }
        }
    }
}
