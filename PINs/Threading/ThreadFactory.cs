using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;

namespace PINs.Threading
{
    public class ThreadFactory
    {
        public static PINThread createThread(PINThreadName ThreadName, ILog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            PINThread thread = null;
            switch (ThreadName)
            {
                case PINThreadName.GetNumber:
                    thread = new ThreadGetNumber(_log, _tokenSource, _threadParameter);
                    break;
                default:
                    break;
            }
            return thread;
        }
    }
}
