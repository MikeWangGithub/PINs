using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PINs.Tools;

namespace PINs.Tools
{
    /// <summary>
    /// Concrete Log Class
    /// </summary>
    public class ConsoleLogger : ILog
    {
        //component which will show the information
        private  RichTextBox _richTextBox;

        public ConsoleLogger():base()
        {
            
        }
        public void SetObject(object obj)
        {
            if (obj != null) {
                try { 
                    _richTextBox = (RichTextBox)obj;
                }
                catch
                {

                }
            }
        }
        public void Info(string infoText)
        {
            RecordColorLog($"[{DateTime.Now.ToString("yy-MM-dd HH:mm")}][Info]:{infoText}", System.Drawing.Color.White);
        }

        public void Debug(string debugText)
        {
            RecordColorLog($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}][Debug]:{debugText}", System.Drawing.Color.YellowGreen);
        }

        public void Warn(string warmText)
        {
            RecordColorLog($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}][Warn]:{warmText}", System.Drawing.Color.Blue);
        }

        public void Error(string errorText, Exception exception)
        {
            RecordColorLog($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}][Error]:{errorText} - Exception:{exception.Message}", System.Drawing.Color.Red);
        }

        public void RecordColorLog(string text, System.Drawing.Color color)
        {
            if (this._richTextBox == null) return;
            if (this._richTextBox.InvokeRequired)
            {
                this._richTextBox.Parent.Invoke(new InvokeLogWithColor(RecordColorLog), new object[] { text, color });
            }
            else
            {
                int start, len;
                if (this._richTextBox.Text == null)
                {
                    this._richTextBox.Text = "" ;
                }

                start = this._richTextBox.TextLength;
                len = text.Length;
                this._richTextBox.AppendText(text);
                this._richTextBox.Select(start, len);
                this._richTextBox.SelectionColor = color;
                this._richTextBox.ScrollToCaret();
                
            }
        }

        

    }
}
