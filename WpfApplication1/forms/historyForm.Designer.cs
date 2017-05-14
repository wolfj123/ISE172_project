﻿namespace WpfApplication1.forms
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
            this.title.Location = new System.Drawing.Point(20, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(70, 24);
            this.title.TabIndex = 0;
            this.title.Text = "History";
            this.title.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose to view history by date or by day";
            // 
            // byDayRB
            // 
            this.byDayRB.AutoSize = true;
            this.byDayRB.Location = new System.Drawing.Point(32, 82);
            this.byDayRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byDayRB.Name = "byDayRB";
            this.byDayRB.Size = new System.Drawing.Size(91, 28);
            this.byDayRB.TabIndex = 10;
            this.byDayRB.Text = "by days";
            this.byDayRB.UseVisualStyleBackColor = true;
            this.byDayRB.CheckedChanged += new System.EventHandler(this.byDayRB_CheckedChanged);
            // 
            // byDateRB
            // 
            this.byDateRB.AutoSize = true;
            this.byDateRB.Location = new System.Drawing.Point(32, 165);
            this.byDateRB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byDateRB.Name = "byDateRB";
            this.byDateRB.Size = new System.Drawing.Size(92, 28);
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
            this.monthCalendar1.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(14, 209);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
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
            this.showHistButton.BackColor = System.Drawing.Color.CadetBlue;
            this.showHistButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showHistButton.Location = new System.Drawing.Point(15, 480);
            this.showHistButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showHistButton.Name = "showHistButton";
            this.showHistButton.Size = new System.Drawing.Size(144, 48);
            this.showHistButton.TabIndex = 14;
            this.showHistButton.Text = "show history";
            this.showHistButton.UseVisualStyleBackColor = false;
            this.showHistButton.Click += new System.EventHandler(this.showHistButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightCyan;
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(385, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(570, 468);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(15, 118);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 31);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // deleteHistoryButton
            // 
            this.deleteHistoryButton.BackColor = System.Drawing.Color.CadetBlue;
            this.deleteHistoryButton.Enabled = false;
            this.deleteHistoryButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteHistoryButton.Location = new System.Drawing.Point(165, 479);
            this.deleteHistoryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteHistoryButton.Name = "deleteHistoryButton";
            this.deleteHistoryButton.Size = new System.Drawing.Size(144, 49);
            this.deleteHistoryButton.TabIndex = 17;
            this.deleteHistoryButton.Text = "delete history";
            this.deleteHistoryButton.UseVisualStyleBackColor = false;
            this.deleteHistoryButton.Click += new System.EventHandler(this.deleteHistoryButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.CadetBlue;
            this.exitButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(855, 489);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 39);
            this.exitButton.TabIndex = 18;
            this.exitButton.Text = "exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // cleanTextButton
            // 
            this.cleanTextButton.BackColor = System.Drawing.Color.CadetBlue;
            this.cleanTextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cleanTextButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanTextButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cleanTextButton.Location = new System.Drawing.Point(385, 489);
            this.cleanTextButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cleanTextButton.Name = "cleanTextButton";
            this.cleanTextButton.Size = new System.Drawing.Size(103, 39);
            this.cleanTextButton.TabIndex = 19;
            this.cleanTextButton.Text = "clean";
            this.cleanTextButton.UseVisualStyleBackColor = false;
            this.cleanTextButton.Click += new System.EventHandler(this.cleanTextButton_Click);
            // 
            // historyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.BackgroundImage = global::WpfApplication1.Properties.Resources.html_page_background_color;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 541);
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
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "historyForm";
            this.Text = "History";
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