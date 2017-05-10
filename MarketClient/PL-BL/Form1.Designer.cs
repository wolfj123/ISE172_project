namespace MarketClient.PL_BL
{
    partial class Form1
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
            this.byDayRB.TabStop = true;
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
            this.byDateRB.TabStop = true;
            this.byDateRB.Text = "by date";
            this.byDateRB.UseVisualStyleBackColor = true;
            this.byDateRB.CheckedChanged += new System.EventHandler(this.byDateRB_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Enabled = false;
            this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monthCalendar1.Location = new System.Drawing.Point(26, 258);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 12;
            // 
            // showHistButton
            // 
            this.showHistButton.Location = new System.Drawing.Point(78, 504);
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
            this.textBox1.Size = new System.Drawing.Size(559, 508);
            this.textBox1.TabIndex = 15;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 627);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.showHistButton);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.byDateRB);
            this.Controls.Add(this.byDayRB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}