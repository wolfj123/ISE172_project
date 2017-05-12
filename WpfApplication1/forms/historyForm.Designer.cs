namespace WpfApplication1.forms
{
    partial class historyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.byDayRB = new System.Windows.Forms.RadioButton();
            this.byDateRB = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.showHistButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.deleteHistoryButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.exitButton = new System.Windows.Forms.Button();
            this.cleanTextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.title.Location = new System.Drawing.Point(39, 23);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(52, 17);
            this.title.TabIndex = 0;
            this.title.Text = "History";
            this.title.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose to view history by date or by day";
            // 
            // byDayRB
            // 
            this.byDayRB.AutoSize = true;
            this.byDayRB.Location = new System.Drawing.Point(78, 111);
            this.byDayRB.Name = "byDayRB";
            this.byDayRB.Size = new System.Drawing.Size(78, 21);
            this.byDayRB.TabIndex = 10;
            this.byDayRB.Text = "by days";
            this.byDayRB.UseVisualStyleBackColor = true;
            this.byDayRB.CheckedChanged += new System.EventHandler(this.byDayRB_CheckedChanged);
            // 
            // byDateRB
            // 
            this.byDateRB.AutoSize = true;
            this.byDateRB.Location = new System.Drawing.Point(78, 225);
            this.byDateRB.Name = "byDateRB";
            this.byDateRB.Size = new System.Drawing.Size(76, 21);
            this.byDateRB.TabIndex = 11;
            this.byDateRB.Text = "by date";
            this.byDateRB.UseVisualStyleBackColor = true;
            this.byDateRB.CheckedChanged += new System.EventHandler(this.byDateRB_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.AnnuallyBoldedDates = new System.DateTime[] {
        new System.DateTime(((long)(0))),
        new System.DateTime(((long)(0)))};
            this.monthCalendar1.BoldedDates = new System.DateTime[] {
        new System.DateTime(((long)(0))),
        new System.DateTime(((long)(0)))};
            this.monthCalendar1.Enabled = false;
            this.monthCalendar1.Location = new System.Drawing.Point(42, 258);
            this.monthCalendar1.MaxSelectionCount = 40;
            this.monthCalendar1.MonthlyBoldedDates = new System.DateTime[] {
        new System.DateTime(((long)(0))),
        new System.DateTime(((long)(0)))};
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ScrollChange = 2;
            this.monthCalendar1.TabIndex = 12;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // showHistButton
            // 
            this.showHistButton.Location = new System.Drawing.Point(12, 504);
            this.showHistButton.Name = "showHistButton";
            this.showHistButton.Size = new System.Drawing.Size(127, 27);
            this.showHistButton.TabIndex = 14;
            this.showHistButton.Text = "show history";
            this.showHistButton.UseVisualStyleBackColor = true;
            this.showHistButton.Click += new System.EventHandler(this.showHistButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(521, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(559, 468);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(110, 171);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // deleteHistoryButton
            // 
            this.deleteHistoryButton.Enabled = false;
            this.deleteHistoryButton.Location = new System.Drawing.Point(145, 504);
            this.deleteHistoryButton.Name = "deleteHistoryButton";
            this.deleteHistoryButton.Size = new System.Drawing.Size(130, 27);
            this.deleteHistoryButton.TabIndex = 17;
            this.deleteHistoryButton.Text = "delete history";
            this.deleteHistoryButton.UseVisualStyleBackColor = true;
            this.deleteHistoryButton.Click += new System.EventHandler(this.deleteHistoryButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(281, 504);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(130, 27);
            this.exitButton.TabIndex = 18;
            this.exitButton.Text = "exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // cleanTextButton
            // 
            this.cleanTextButton.Location = new System.Drawing.Point(746, 504);
            this.cleanTextButton.Name = "cleanTextButton";
            this.cleanTextButton.Size = new System.Drawing.Size(146, 41);
            this.cleanTextButton.TabIndex = 19;
            this.cleanTextButton.Text = "clean";
            this.cleanTextButton.UseVisualStyleBackColor = true;
            this.cleanTextButton.Click += new System.EventHandler(this.cleanTextButton_Click);
            // 
            // historyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1176, 557);
            this.Controls.Add(this.cleanTextButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteHistoryButton);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.showHistButton);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.byDateRB);
            this.Controls.Add(this.byDayRB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Name = "historyForm";
            this.Text = "exit";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton byDayRB;
        private System.Windows.Forms.RadioButton byDateRB;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button showHistButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button deleteHistoryButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button cleanTextButton;
    }
}