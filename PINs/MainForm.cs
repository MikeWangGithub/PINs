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
using PINs.GlobalData;

namespace PINs
{
    public partial class MainForm : Form
    {
        #region  variable
        /// <summary>
        /// MulitThread variable and record the valid PIN
        /// </summary>
        private Task<int> task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initial();
        }

        public void Initial()
        {
            //Initial Global System Configuration
            SystemConfiguration.Initial(System.Windows.Forms.Application.ExecutablePath);
            //Inital Global LogClass
            LoggerHelper.Initial(this.txtLog);
            //Clear TextBox.Text 
            this.txtNumber.Clear();
            this.txtNumber.ReadOnly = true;
            //Clear TextBox.Text 
            this.txtCheckPIN.Clear();
            this.txtCheckPIN.ReadOnly = false;
            //Don't need to wait thread. So don't use await and async
            RunThread(PINThreadName.DigitInitial);
            
        }

        #region Threading functions
        /// <summary>
        /// Cancel Thread.
        /// </summary>
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
        /// <summary>
        /// Set tokenSource for Start a new Thread
        /// </summary>
        /// <returns></returns>
        private CancellationTokenSource StartNewTask()
        {
            tokenSource = new CancellationTokenSource();
            return tokenSource;
        }
        /// <summary>
        /// Execute a thread
        /// </summary>
        /// <param name="ThreadName"></param>
        /// <returns></returns>
        private async Task<int> RunThread(PINThreadName ThreadName)
        {
            DateTime dt1, dt2;
            dt1 = System.DateTime.Now;
            int rtn = -1;
            try
            {
                //Set buttons enabled to be disenable
                this.SetButtonStatus(ThreadName, false);
                
                CancellationTokenSource tokenSource = StartNewTask();
                //Get threadparameter
                ICloneable param = GetParameter(ThreadName);
                //Get context for to execute thread
                ThreadContext threadContext = new ThreadContext(ThreadName, tokenSource, param);
                //Thread  running
                task = threadContext.ThreadRun();
                // wait thread is over
                rtn = await task;
                
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("Task<int> RunThread Function", ex);
                
            }
            finally
            {
                //Set buttons enabled from disabled to enabled.
                this.SetButtonStatus(ThreadName, true);
                dt2 = System.DateTime.Now;
                if (SystemConfiguration.Debug) {
                    LoggerHelper.Debug("[" + ThreadName.ToString() + "] is finished. It took " + (dt2 - dt1).ToString() + "\r\n");
                }
            }
            return rtn;
        }
        /// <summary>
        /// get parameter
        /// </summary>
        /// <param name="ThreadName"></param>
        /// <returns></returns>
        private ICloneable GetParameter(PINThreadName ThreadName)
        {
            ICloneable param = null;
            switch (ThreadName)
            {
                case PINThreadName.GetNumber:
                    param = this.GetGetNumberParameter();
                    break;
                case PINThreadName.DigitInitial:
                    param = this.GetDigitInitialParameter();
                    break;
                default:
                    break;
            }
            return param;
        }

        private ICloneable GetGetNumberParameter()
        {
            return null;

        }
        private DigitInitialParameter GetDigitInitialParameter()
        {
            //Delegate function for show the quantity after get a new PIN
            DigitInitialParameter param = new DigitInitialParameter();
            param.SetRefreshQuantityFunction(this.RefreshQuantity);
            return param;

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
        /// <summary>
        /// Set buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetDigitInitialButtonStatus(bool isEnabled)
        {
            this.btnCheckPIN.Enabled = isEnabled;
            SetGetNumberButtonStatus(isEnabled);

        }
        /// <summary>
        /// Set buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetButtonStatus(PINThreadName ThreadName, bool flag)
        {
            switch (ThreadName)
            {
                case PINThreadName.GetNumber:
                    this.SetGetNumberButtonStatus(flag);
                    break;
                case PINThreadName.DigitInitial:
                    this.SetDigitInitialButtonStatus(flag);
                    break;
                default:
                    break;
            }
        }
        #endregion End Button Status controll

        /// <summary>
        /// Get number
        /// </summary>
        private async void BtnGetNumber_Click(object sender, EventArgs e)
        {
            //Initial Digit Set
            if (!DigitSet.DigitSetStatus)
            {
                await RunThread(PINThreadName.DigitInitial);
            }
            //Execute async thread
            int randomDigtit = await RunThread(PINThreadName.GetNumber);
            if (randomDigtit >= SystemConfiguration.MinDigit) {
                //get a valid PIN
                this.txtNumber.Text = randomDigtit.ToString();
                RefreshQuantity();
            }
            else
            {
                //Digit run out
                if(System.Windows.Forms.MessageBox.Show("All of the digits have been used. Do you want to reuse the preceding digits?\r\n\r\nIf you click \"Yes\", all of the used digits will be cleared , then the digits can be used again.\r\nIf you click \"No\" ,nothing will happen."
                    ,"Infomation"
                    , MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DigitSet.ExceptionSet.Clear(SystemConfiguration.ExceptionDigitDataSet);
                    DigitSet.UnusedSet.Clear(SystemConfiguration.UnusedDigitDataSet);
                    DigitSet.UsedSet.Clear(SystemConfiguration.UsedDigitDataSet);
                    DigitSet.SetReInitial();
                    this.BtnGetNumber_Click(sender, e);
                }
            }

        }
        /// <summary>
        /// Update quantity
        /// </summary>
        private void RefreshQuantity()
        {
            if (this.lbUsedPINQuantity.InvokeRequired)
            {
                this.lbUsedPINQuantity.Parent.Invoke(new SafeCallDelegate(this.RefreshQuantity));
            }
            else
            {
                this.lbUsedPINQuantity.Text = DigitSet.UsedSet.Length.ToString();
            }
        }

        /// <summary>
        /// Call CheckPIN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnCheckPIN_Click(object sender, EventArgs e)
        {
            if (!DigitSet.DigitSetStatus)
            {
                await RunThread(PINThreadName.DigitInitial);
            }
            CheckPIN(txtCheckPIN.Text.Trim());
        }
        //Check if a PIN is valid and has been used
        private void CheckPIN(string text)
        {
            int digit = 0;
            try
            {
                digit = System.Convert.ToInt32(text);
            }
            catch
            {
                LoggerHelper.Warn("[" + text + "] is not a valid integer \r\n");
                return;
            }
            if (DigitSet.UsedSet.Contains(digit))
            {
                LoggerHelper.Info("[" + text + "] is a valid digit and has been used.\r\n");
            }
            else
            {
                if (PINRegularExpression.IsValidDigit(digit,SystemConfiguration.RightNumberRegex,SystemConfiguration.ExceptionNumberRegex))
                {
                    LoggerHelper.Info("[" + text + "] has not been used and this is a valid digit.\r\n");
                }
                else
                {
                    LoggerHelper.Info("[" + text + "] has not been used and this is a invalid digit.\r\n");
                }
            }
            

        }
    }
}

