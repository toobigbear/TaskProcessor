namespace TaskProcessor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCount = new Label();
            numCount = new NumericUpDown();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            lblCurrent = new Label();
            btnStart = new Button();
            btnCancel = new Button();
            label1 = new Label();
            lstLog = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numCount).BeginInit();
            SuspendLayout();
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(48, 24);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(100, 24);
            lblCount.TabIndex = 0;
            lblCount.Text = "任务数量：";
            // 
            // numCount
            // 
            numCount.Location = new Point(184, 24);
            numCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCount.Name = "numCount";
            numCount.Size = new Size(100, 30);
            numCount.TabIndex = 1;
            numCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // progressBar
            // 
            progressBar.Location = new Point(48, 72);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(240, 34);
            progressBar.TabIndex = 2;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(304, 72);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(37, 24);
            lblProgress.TabIndex = 3;
            lblProgress.Text = "0%";
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(144, 120);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(46, 24);
            lblCurrent.TabIndex = 4;
            lblCurrent.Text = "就绪";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(48, 160);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 5;
            btnStart.Text = "开始任务";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(184, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 120);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 7;
            label1.Text = "当前任务：";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(16, 216);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(352, 124);
            lstLog.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 354);
            Controls.Add(lstLog);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnStart);
            Controls.Add(lblCurrent);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(numCount);
            Controls.Add(lblCount);
            MaximizeBox = false;
            Name = "Form1";
            Text = "批量任务处理器";
            ((System.ComponentModel.ISupportInitialize)numCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCount;
        private NumericUpDown numCount;
        private ProgressBar progressBar;
        private Label lblProgress;
        private Label lblCurrent;
        private Button btnStart;
        private Button btnCancel;
        private Label label1;
        private ListBox lstLog;
    }
}
