using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;
using PINs.Algorithm;
using PINs.Threading;

namespace PINs.Threading
{
    public class ThreadGenerateBinaryTree:PINThread
    {
        private ParameterSystem param;
        private RedBlackTree UsedRedBlackTree;
        private RedBlackTree UnusedRedBlackTree;
        private RedBlackTree ExceptionRedBlackTree;
        public ThreadGenerateBinaryTree(ILog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            param = (ParameterSystem)this.ThreadParameter;
            UsedRedBlackTree = new RedBlackTree(this.log);
            UnusedRedBlackTree = new RedBlackTree(this.log);
            ExceptionRedBlackTree = new RedBlackTree(this.log);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true : Need to generate 3 files; false: Don't need this operation</returns>
        public override bool CheckParameter()
        {
            return true;
        }


        public override int RunSubThread()
        {
            this.IsTaskCanceled();
            
            return 0;
        }

        
        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            if (param.Debug)
            {
                log.Debug(this.GetType().ToString() + " threading started.\r\n");
            }
            

        }
        public override void DoSomethingAfterRunSub()
        {
            base.DoSomethingAfterRunSub();
            if (param.Debug)
            {
                log.Debug(this.GetType().ToString() + " threading finished.\r\n");
            }
            
        }
    }
}
