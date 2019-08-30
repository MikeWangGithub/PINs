namespace PINs
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnGetNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUsedPINQuantity = new System.Windows.Forms.Label();
            this.toolTipCheckPIN = new System.Windows.Forms.ToolTip(this.components);
            this.btnCheckPIN = new System.Windows.Forms.Button();
            this.txtCheckPIN = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1094, 166);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 523);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(1094, 523);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtNumber);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetNumber);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtCheckPIN);
            this.splitContainer1.Panel2.Controls.Add(this.btnCheckPIN);
            this.splitContainer1.Panel2.Controls.Add(this.lbUsedPINQuantity);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 146);
            this.splitContainer1.SplitterDistance = 616;
            this.splitContainer1.TabIndex = 3;
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.Font = new System.Drawing.Font("微软雅黑", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNumber.Location = new System.Drawing.Point(23, 6);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(278, 134);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.Text = "2222";
            // 
            // btnGetNumber
            // 
            this.btnGetNumber.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetNumber.Location = new System.Drawing.Point(307, 6);
            this.btnGetNumber.Name = "btnGetNumber";
            this.btnGetNumber.Size = new System.Drawing.Size(278, 134);
            this.btnGetNumber.TabIndex = 3;
            this.btnGetNumber.Text = "Get a new PIN";
            this.btnGetNumber.UseVisualStyleBackColor = true;
            this.btnGetNumber.Click += new System.EventHandler(this.BtnGetNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantity of used PINs";
            // 
            // lbUsedPINQuantity
            // 
            this.lbUsedPINQuantity.AutoSize = true;
            this.lbUsedPINQuantity.Font = new System.Drawing.Font("宋体", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUsedPINQuantity.ForeColor = System.Drawing.Color.Fuchsia;
            this.lbUsedPINQuantity.Location = new System.Drawing.Point(285, 20);
            this.lbUsedPINQuantity.Name = "lbUsedPINQuantity";
            this.lbUsedPINQuantity.Size = new System.Drawing.Size(0, 21);
            this.lbUsedPINQuantity.TabIndex = 1;
            // 
            // toolTipCheckPIN
            // 
            this.toolTipCheckPIN.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnCheckPIN
            // 
            this.btnCheckPIN.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckPIN.Location = new System.Drawing.Point(289, 80);
            this.btnCheckPIN.Name = "btnCheckPIN";
            this.btnCheckPIN.Size = new System.Drawing.Size(170, 35);
            this.btnCheckPIN.TabIndex = 3;
            this.btnCheckPIN.Text = "Check a PIN";
            this.toolTipCheckPIN.SetToolTip(this.btnCheckPIN, "1. Input a PIN.\r\n2. Show this PIN has been used or not.\r\n3. Show this PIN is a va" +
        "lid digit or not.");
            this.btnCheckPIN.UseVisualStyleBackColor = true;
            this.btnCheckPIN.Click += new System.EventHandler(this.BtnCheckPIN_Click);
            // 
            // txtCheckPIN
            // 
            this.txtCheckPIN.BackColor = System.Drawing.SystemColors.Info;
            this.txtCheckPIN.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckPIN.Location = new System.Drawing.Point(21, 80);
            this.txtCheckPIN.Name = "txtCheckPIN";
            this.txtCheckPIN.Size = new System.Drawing.Size(258, 35);
            this.txtCheckPIN.TabIndex = 6;
            this.txtCheckPIN.Text = "2222";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PINs";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnGetNumber;
        private System.Windows.Forms.Label lbUsedPINQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTipCheckPIN;
        private System.Windows.Forms.Button btnCheckPIN;
        private System.Windows.Forms.TextBox txtCheckPIN;
    }
}

