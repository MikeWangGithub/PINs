using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PINs.Tools;
using PINs.Threading;
using System.Configuration;
using PINs.Algorithm;

namespace PINs
{
    public partial class MainForm : Form
    {
        #region  variable
        //private delegate void SafeCallDelegateLog(string text);
        //private delegate void SafeCallDelegateDeleteLog(int line);
        //public delegate void InvokeLogWithoutColor(string text, bool medEnterteck);
        //public delegate void InvokeLogWithColor(string text, System.Drawing.Color color, bool medEnterteck);
        public delegate void SetbuttonStatus(bool flag);



        private Task task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        //private int CheckNumber = 0;
        //private CancellationToken token;


        private ILog log;
        private ParameterSystem parameterSystem;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initial();
        }

        public void Initial()
        {
            parameterSystem = new ParameterSystem();
            this.txtNumber.Clear();
            //string key = AppConfig.GetAppConfig("Logger");
            log = ObjectBuildFactory<ILog>.Instance(parameterSystem.LoggerClassName);
            log.SetObject(this.txtLog);
        }
   
        #region Threading functions
        private void CancelTask()
        {
            if (tokenSource != null)
            {
                if (tokenSource.IsCancellationRequested == false)
                {
                    tokenSource.Cancel();
                }
            }
        }
        private CancellationTokenSource StartNewTask()
        {
            tokenSource = new CancellationTokenSource();
            // token = tokenSource.Token;
            return tokenSource;
        }
        private async Task RunThread(PINThreadName ThreadName)
        {
            DateTime dt1, dt2;
            dt1 = System.DateTime.Now;
            try
            {

                this.SetButtonStatus(ThreadName, false);
                CancellationTokenSource tokenSource = StartNewTask();
                ICloneable param = GetParameter(ThreadName);
                ThreadContext threadContext = new ThreadContext(ThreadName, this.log, tokenSource, param);
                this.log.Info("[" + ThreadName.ToString() + "] started.\r\n");
                task = threadContext.ThreadRun();
                await task;
                //
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message, ex);
                //this.SetFolderButtonStatus(true);
            }
            finally
            {
                this.SetButtonStatus(ThreadName, true);
                dt2 = System.DateTime.Now;
                log.Info("[" + ThreadName.ToString() + "] is finished. Time is " + (dt2 - dt1).ToString());
            }
        }
       
        private ICloneable GetParameter(PINThreadName ThreadName)
        {
            ICloneable param = null;
            switch (ThreadName)
            {
                case PINThreadName.GetNumber:
                    param = this.GetGetNumberParameter();
                    break;
                
                default:
                    break;
            }
            return param;
        }

        private ParameterSystem GetGetNumberParameter()
        {
            

            return this.parameterSystem;

        }
        #endregion End Threading functions

        #region Button Status controll
        /// <summary>
        /// Set buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetGetNumberButtonStatus(bool isEnabled)
        {
            this.btnGetNumber.Enabled = isEnabled;
            
        }
        private void SetButtonStatus(PINThreadName ThreadName, bool flag)
        {
            switch (ThreadName)
            {
                case PINThreadName.GetNumber:
                    this.SetGetNumberButtonStatus(flag);
                    break;
                default:
                    break;
            }
        }
        #endregion End Button Status controll

        private async void BtnGetNumber_Click(object sender, EventArgs e)
        {
            await RunThread(PINThreadName.GetNumber);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //this.log.Info(AppConfig.GetAppConfig("ObviousNumber")+"\r\n");
            if(RegularExpression.IsRightFormat(this.txtNumber.Text, parameterSystem.RightFormat)){ 
                if (RegularExpression.IsMatch(this.txtNumber.Text,parameterSystem.Regex))
                {
                    this.log.Warn(this.txtNumber.Text + " is not a valid digit\r\n");
                }
                else
                {
                    this.log.Info(this.txtNumber.Text + " is a valid digit\r\n");
                }
            }
            else
            {
                this.log.Warn(this.txtNumber.Text + " is not a valid digit\r\n");
            }
        }
    }
}
