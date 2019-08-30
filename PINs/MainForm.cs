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
            SystemConfiguration.Initial(System.Windows.Forms.Application.ExecutablePath);
            LoggerHelper.Initial(this.txtLog);
            this.txtNumber.Clear();
            this.txtCheckPIN.Clear();
            //Don't need to wait thread. So don't use await and async
            RunThread(PINThreadName.DigitInitial);
            //LoggerHelper.Info("Form Initial finished.");

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
            return tokenSource;
        }
        private async Task<int> RunThread(PINThreadName ThreadName)
        {
            DateTime dt1, dt2;
            dt1 = System.DateTime.Now;
            int rtn = -1;
            try
            {

                this.SetButtonStatus(ThreadName, false);
                CancellationTokenSource tokenSource = StartNewTask();
                ICloneable param = GetParameter(ThreadName);
                ThreadContext threadContext = new ThreadContext(ThreadName, LoggerHelper.log, tokenSource, param);
                task = threadContext.ThreadRun();
                rtn = await task;
                
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("Task<int> RunThread Function", ex);
                
            }
            finally
            {
                this.SetButtonStatus(ThreadName, true);
                dt2 = System.DateTime.Now;
                if (SystemConfiguration.Debug) {
                    LoggerHelper.Debug("[" + ThreadName.ToString() + "] is finished. It took " + (dt2 - dt1).ToString() + "\r\n");
                }
            }
            return rtn;
        }
       
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
        private void SetDigitInitialButtonStatus(bool isEnabled)
        {
            this.btnCheckPIN.Enabled = isEnabled;

        }
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

        private async void BtnGetNumber_Click(object sender, EventArgs e)
        {
            if (!DigitSet.DigitSetStatus)
            {
                await RunThread(PINThreadName.DigitInitial);
            }
            int randomDigtit = await RunThread(PINThreadName.GetNumber);
            if (randomDigtit >= SystemConfiguration.MinDigit) { 
                this.txtNumber.Text = randomDigtit.ToString();
                RefreshQuantity();
            }
            else
            {
                //Digit run out
                if(System.Windows.Forms.MessageBox.Show("All of digits have been used. Do you want to rebuild unused digits?\r\n\r\nIf you click \"Yes\", then program will create the same new unused digits' set as the beginning.\r\nIf you click \"No\" ,do nothing."
                    ,"Infomation"
                    , MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.IO.File.Delete(SystemConfiguration.ExceptionDigitFileName);
                    System.IO.File.Delete(SystemConfiguration.UnusedDigitFileName);
                    System.IO.File.Delete(SystemConfiguration.UsedDigitFileName);
                    DigitSet.SetReInitial();
                    this.BtnGetNumber_Click(sender, e);
                }
            }

        }
        private void RefreshQuantity()
        {
            if (this.lbUsedPINQuantity.InvokeRequired)
            {
                this.lbUsedPINQuantity.Parent.Invoke(new SafeCallDelegate(this.RefreshQuantity));
            }
            else
            {
                this.lbUsedPINQuantity.Text = DigitSet.UsedHash.Length.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //for(int i = 1; i <= 9995; i++)
            //{
            //    this.BtnGetNumber_Click(null, null);

            //}

        }

        private async void BtnCheckPIN_Click(object sender, EventArgs e)
        {
            if (!DigitSet.DigitSetStatus)
            {
                await RunThread(PINThreadName.DigitInitial);
            }
            CheckPIN(txtCheckPIN.Text.Trim());
        }
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
            if (DigitSet.UsedHash.Contains(digit))
            {
                LoggerHelper.Info("[" + text + "] is a valid digit and hasn't been used.\r\n");
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


//int num = 9999999 + 1;
//DateTime dt1, dt2;
//dt1 = System.DateTime.Now;
//            this.log.Info("Create array :quantity=" + num.ToString() + "\r\n");
//            int[]
//ArrayUnused = new int[num];
//            dt2 = System.DateTime.Now;
//            this.log.Info("Create array :quantity=" + (dt2-dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("Traverse array begin..." + num.ToString() + "\r\n");
//            for (int i=0; i<num; i++){
//    ArrayUnused[i] = 0;
//}
//dt2 = System.DateTime.Now;
//            this.log.Info("Traverse array end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("create HashObject begin..." + num.ToString() + "\r\n");
//PINHash hash = new PINHash(this.log);
//            for (int i = 0; i<num; i++)
//            {
//                hash.Insert(i);
//            }
//            dt2 = System.DateTime.Now;
//            this.log.Info("create HashObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("Traverse HashObject begin..." + num.ToString() + "\r\n");
//            foreach (var item in hash.Hash)
//            {
//    //
//}
//dt2 = System.DateTime.Now;
//            this.log.Info("Traverse HashObject end" + (dt2 - dt1).ToString("") + "\r\n");


//dt1 = System.DateTime.Now;
//            this.log.Info("Create RedBlackTree begin..." + num.ToString() + "\r\n");
//RedBlackTree btree = new RedBlackTree(this.log);
//            for (int i = 0; i<num; i++)
//            {
//                btree.Insert(i);
//            }
//            dt2 = System.DateTime.Now;
//            this.log.Info("Create RedBlackTree end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("Traverse RedBlackTree begin..." + num.ToString() + "\r\n");
//            foreach (var item in btree.RBTree)
//            {
//    //
//}
//dt2 = System.DateTime.Now;
//            this.log.Info("Traverse RedBlackTree end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("Search Time: HashObject begin..." + (num-1).ToString() + "\r\n");
//hash.Contains(num-1);
//dt2 = System.DateTime.Now;
//            this.log.Info("Search Time: HashObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("Search Time: RedBlackTreeObject begin..." + (num-1).ToString() + "\r\n");
//btree.Contains(num-1);
//dt2 = System.DateTime.Now;
//            this.log.Info("Search Time: RedBlackTreeObject end" + (dt2 - dt1).ToString("") + "\r\n");


//dt1 = System.DateTime.Now;
//            this.log.Info("GetValueByIndex: HashObject begin..." + (num - 1).ToString() + "\r\n");
//hash.GetValue(num - 1);
//dt2 = System.DateTime.Now;
//            this.log.Info("GetValueByIndex: HashObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("GetValueByIndex: RedBlackTreeObject begin..." + (num - 1).ToString() + "\r\n");
//btree.GetValue(num - 1);
//dt2 = System.DateTime.Now;
//            this.log.Info("GetValueByIndex: RedBlackTreeObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("SaveToFile: HashObject begin..." + (num - 1).ToString() + "\r\n");
//hash.SaveToFile(@"c:/test/hash.txt");
//dt2 = System.DateTime.Now;
//            this.log.Info("SaveToFile: HashObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("SaveToFile: RedBlackTreeObject begin..." + (num - 1).ToString() + "\r\n");
//btree.SaveToFile(@"c:/test/btree.txt");
//dt2 = System.DateTime.Now;
//            this.log.Info("SaveToFile: RedBlackTreeObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("OpenFromFile: HashObject begin..." + (num - 1).ToString() + "\r\n");
//hash.OpenFromFile(@"c:/test/hash.txt");
//dt2 = System.DateTime.Now;
//            this.log.Info("OpenFromFile: HashObject end" + (dt2 - dt1).ToString("") + "\r\n");

//dt1 = System.DateTime.Now;
//            this.log.Info("OpenFromFile: RedBlackTreeObject begin..." + (num - 1).ToString() + "\r\n");
//btree.OpenFromFile(@"c:/test/btree.txt");
//dt2 = System.DateTime.Now;
//            this.log.Info("OpenFromFile: RedBlackTreeObject end" + (dt2 - dt1).ToString("") + "\r\n");

