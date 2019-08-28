using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PINs.Tools;
using System.Threading;

namespace PINs.Threading
{
    public class ThreadGetNumber:PINThread
    {
        private ParameterSystem param;
        public ThreadGetNumber(ILog _log, CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_log, _tokenSource, _threadParameter)
        {
            //List<string> commandList = new List<string>();
            //CheckNumber = 0;
            
            param = (ParameterSystem)this.ThreadParameter;
        }

        public override bool CheckParameter()
        {
            //Check ParameterGetNumber
            //
            return true;
        }


        public override void RunSubThread()
        {
            this.IsTaskCanceled();
            
        }

        
        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            //commandList.Clear();
            //log.Log("Time\t\tFileName");

        }
        public override void DoSomethingAfterRunSub()
        {
            base.DoSomethingAfterRunSub();
            //FileInfo finfo = new FileInfo(((LibreOfficeParameter)this.ThreadParameter).BatchFile);

            //if (!System.IO.Directory.Exists(finfo.DirectoryName))
            //{
            //    System.IO.Directory.CreateDirectory(finfo.DirectoryName);
            //}
            //using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(((LibreOfficeParameter)this.ThreadParameter).BatchFile, false))
            //{
            //    foreach (string line in commandList)
            //    {
            //        // If the line doesn't contain the word 'Second', write the line to the file.

            //        file.WriteLine(line);

            //    }
            //}
            //DeleteLog(2);
            //log.LogTaskEnd();
        }
    }
}
