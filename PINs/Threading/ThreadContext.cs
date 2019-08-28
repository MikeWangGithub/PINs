using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;

namespace PINs.Threading
{
    public class ThreadContext
    {
        private PINThread superThread = null;
        public ThreadContext(PINThreadName ThreadName,
                             ILog _log,
                             CancellationTokenSource _tokenSource,
                             ICloneable _threadParameter)
        {
            superThread = ThreadFactory.createThread(ThreadName,
                                                     _log,
                                                     _tokenSource,
                                                     _threadParameter);
        }

        public Task ThreadRun()
        {
            if (superThread != null)
            {
                return superThread.Run();
            }
            else { return null; }
        }
    }
}
