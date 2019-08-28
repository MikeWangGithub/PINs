﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PINs.Tools;

namespace PINs.Tools
{
    public class ConsoleLogger : ILog
    {
        private RichTextBox _richTextBox;

        public ConsoleLogger():base()
        {
            
        }
        public void SetObject(object obj)
        {
            this._richTextBox = (RichTextBox)obj;
        }
        public void Info(string infoText)
        {
            RecordColorLog($"[{DateTime.Now}][Info]:{infoText}", System.Drawing.Color.White);
        }

        public void Debug(string debugText)
        {
            RecordColorLog($"[{DateTime.Now}][Debug]:{debugText}", System.Drawing.Color.YellowGreen);
        }

        public void Warn(string warmText)
        {
            RecordColorLog($"[{DateTime.Now}][Warm]:{warmText}", System.Drawing.Color.Blue);
        }

        public void Error(string errorText, Exception exception)
        {
            RecordColorLog($"[{DateTime.Now}][Error]:{errorText} - Exception:{exception.Message}", System.Drawing.Color.Red);
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
                
            }
        }

        

    }
}