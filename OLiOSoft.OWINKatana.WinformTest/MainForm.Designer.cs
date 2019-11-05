namespace OLiOSoft.OWINKatana.WinformTest
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
            this.StartTestHost = new System.Windows.Forms.Button();
            this.StartTestHost1 = new System.Windows.Forms.Button();
            this.StopTestHost = new System.Windows.Forms.Button();
            this.StopTestHost1 = new System.Windows.Forms.Button();
            this.ReleaseHost = new System.Windows.Forms.Button();
            this.LogMessage = new System.Windows.Forms.ListBox();
            this.LogSomething = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartTestHost
            // 
            this.StartTestHost.Location = new System.Drawing.Point(0, 0);
            this.StartTestHost.Name = "StartTestHost";
            this.StartTestHost.Size = new System.Drawing.Size(178, 23);
            this.StartTestHost.TabIndex = 0;
            this.StartTestHost.Text = "打开9000";
            this.StartTestHost.UseVisualStyleBackColor = true;
            this.StartTestHost.Click += new System.EventHandler(this.StartTestHost_Click);
            // 
            // StartTestHost1
            // 
            this.StartTestHost1.Location = new System.Drawing.Point(0, 29);
            this.StartTestHost1.Name = "StartTestHost1";
            this.StartTestHost1.Size = new System.Drawing.Size(197, 23);
            this.StartTestHost1.TabIndex = 1;
            this.StartTestHost1.Text = "打开9001";
            this.StartTestHost1.UseVisualStyleBackColor = true;
            this.StartTestHost1.Click += new System.EventHandler(this.StartTestHost1_Click);
            // 
            // StopTestHost
            // 
            this.StopTestHost.Location = new System.Drawing.Point(184, 0);
            this.StopTestHost.Name = "StopTestHost";
            this.StopTestHost.Size = new System.Drawing.Size(82, 23);
            this.StopTestHost.TabIndex = 2;
            this.StopTestHost.Text = "关闭9000";
            this.StopTestHost.UseVisualStyleBackColor = true;
            this.StopTestHost.Click += new System.EventHandler(this.StopTestHost_Click);
            // 
            // StopTestHost1
            // 
            this.StopTestHost1.Location = new System.Drawing.Point(203, 29);
            this.StopTestHost1.Name = "StopTestHost1";
            this.StopTestHost1.Size = new System.Drawing.Size(82, 23);
            this.StopTestHost1.TabIndex = 3;
            this.StopTestHost1.Text = "关闭9001";
            this.StopTestHost1.UseVisualStyleBackColor = true;
            this.StopTestHost1.Click += new System.EventHandler(this.StopTestHost1_Click);
            // 
            // ReleaseHost
            // 
            this.ReleaseHost.Location = new System.Drawing.Point(218, 415);
            this.ReleaseHost.Name = "ReleaseHost";
            this.ReleaseHost.Size = new System.Drawing.Size(144, 23);
            this.ReleaseHost.TabIndex = 4;
            this.ReleaseHost.Text = "回收所有空闲的";
            this.ReleaseHost.UseVisualStyleBackColor = true;
            this.ReleaseHost.Click += new System.EventHandler(this.ReleaseHost_Click);
            // 
            // LogMessage
            // 
            this.LogMessage.FormattingEnabled = true;
            this.LogMessage.ItemHeight = 12;
            this.LogMessage.Location = new System.Drawing.Point(12, 58);
            this.LogMessage.Name = "LogMessage";
            this.LogMessage.Size = new System.Drawing.Size(350, 352);
            this.LogMessage.TabIndex = 5;
            // 
            // LogSomething
            // 
            this.LogSomething.Location = new System.Drawing.Point(115, 415);
            this.LogSomething.Name = "LogSomething";
            this.LogSomething.Size = new System.Drawing.Size(97, 23);
            this.LogSomething.TabIndex = 6;
            this.LogSomething.Text = "池子数据";
            this.LogSomething.UseVisualStyleBackColor = true;
            this.LogSomething.Click += new System.EventHandler(this.LogSomething_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 450);
            this.Controls.Add(this.LogSomething);
            this.Controls.Add(this.LogMessage);
            this.Controls.Add(this.ReleaseHost);
            this.Controls.Add(this.StopTestHost1);
            this.Controls.Add(this.StopTestHost);
            this.Controls.Add(this.StartTestHost1);
            this.Controls.Add(this.StartTestHost);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartTestHost;
        private System.Windows.Forms.Button StartTestHost1;
        private System.Windows.Forms.Button StopTestHost;
        private System.Windows.Forms.Button StopTestHost1;
        private System.Windows.Forms.Button ReleaseHost;
        private System.Windows.Forms.ListBox LogMessage;
        private System.Windows.Forms.Button LogSomething;
    }
}

