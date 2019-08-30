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
    /// Create different concrete thread by different ThreadName
    /// </summary>
    public class ThreadFactory
    {
        /// <summary>
        /// Create different concrete thread by different ThreadName
        /// </summary>
        public static PINThread createThread(PINThreadName ThreadName, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            PINThread thread = null;
            switch (ThreadName)
            {
                case PINThreadName.GetNumber:
                    thread = new ThreadGetNumber(_tokenSource, _threadParameter);
                    break;
                case PINThreadName.DigitInitial:
                    thread = new ThreadDigitInitial(_tokenSource, _threadParameter);
                    break;
                default:
                    break;
            }
            return thread;
        }
    }
}
