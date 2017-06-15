namespace WpfApplication1.AMA
{
    partial class AddLogicForm
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
            this.buyRadioButton = new System.Windows.Forms.RadioButton();
            this.SellRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.commodityNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.belowAbove = new System.Windows.Forms.Label();
            this.priceNumeric = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bidAsk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.commodityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // buyRadioButton
            // 
            this.buyRadioButton.AutoSize = true;
            this.buyRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.buyRadioButton.Checked = true;
            this.buyRadioButton.Location = new System.Drawing.Point(17, 17);
            this.buyRadioButton.Margin = new System.Windows.Forms.Padding(8);
            this.buyRadioButton.Name = "buyRadioButton";
            this.buyRadioButton.Size = new System.Drawing.Size(44, 17);
            this.buyRadioButton.TabIndex = 0;
            this.buyRadioButton.TabStop = true;
            this.buyRadioButton.Text = "Buy";
            this.buyRadioButton.UseVisualStyleBackColor = false;
            this.buyRadioButton.CheckedChanged += new System.EventHandler(this.buyRadioButton_CheckedChanged);
            // 
            // SellRadioButton
            // 
            this.SellRadioButton.AutoSize = true;
            this.SellRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SellRadioButton.Location = new System.Drawing.Point(17, 40);
            this.SellRadioButton.Margin = new System.Windows.Forms.Padding(8);
            this.SellRadioButton.Name = "SellRadioButton";
            this.SellRadioButton.Size = new System.Drawing.Size(43, 17);
            this.SellRadioButton.TabIndex = 1;
            this.SellRadioButton.Text = "Sell";
            this.SellRadioButton.UseVisualStyleBackColor = false;
            this.SellRadioButton.CheckedChanged += new System.EventHandler(this.SellRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(68, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "of commodity";
            // 
            // commodityNumeric
            // 
            this.commodityNumeric.Location = new System.Drawing.Point(154, 29);
            this.commodityNumeric.Margin = new System.Windows.Forms.Padding(8);
            this.commodityNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.commodityNumeric.Name = "commodityNumeric";
            this.commodityNumeric.Size = new System.Drawing.Size(117, 22);
            this.commodityNumeric.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(26, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "when the";
            // 
            // belowAbove
            // 
            this.belowAbove.AutoSize = true;
            this.belowAbove.BackColor = System.Drawing.Color.Transparent;
            this.belowAbove.Location = new System.Drawing.Point(162, 77);
            this.belowAbove.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.belowAbove.Name = "belowAbove";
            this.belowAbove.Size = new System.Drawing.Size(38, 13);
            this.belowAbove.TabIndex = 6;
            this.belowAbove.Text = "below";
            // 
            // priceNumeric
            // 
            this.priceNumeric.Location = new System.Drawing.Point(216, 75);
            this.priceNumeric.Margin = new System.Windows.Forms.Padding(8);
            this.priceNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.priceNumeric.Name = "priceNumeric";
            this.priceNumeric.Size = new System.Drawing.Size(152, 22);
            this.priceNumeric.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(397, 63);
            this.addButton.Margin = new System.Windows.Forms.Padding(8);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 40);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add Rule";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(103, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "is equal or";
            // 
            // bidAsk
            // 
            this.bidAsk.AutoSize = true;
            this.bidAsk.BackColor = System.Drawing.Color.Transparent;
            this.bidAsk.Location = new System.Drawing.Point(77, 77);
            this.bidAsk.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.bidAsk.Name = "bidAsk";
            this.bidAsk.Size = new System.Drawing.Size(27, 13);
            this.bidAsk.TabIndex = 10;
            this.bidAsk.Text = "ASK";
            // 
            // AddLogicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = global::WpfApplication1.Properties.Resources.html_page_background_color;
            this.ClientSize = new System.Drawing.Size(519, 136);
            this.Controls.Add(this.bidAsk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.priceNumeric);
            this.Controls.Add(this.belowAbove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commodityNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SellRadioButton);
            this.Controls.Add(this.buyRadioButton);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "AddLogicForm";
            this.Text = "Add User Rules";
            ((System.ComponentModel.ISupportInitialize)(this.commodityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton buyRadioButton;
        private System.Windows.Forms.RadioButton SellRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown commodityNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label belowAbove;
        private System.Windows.Forms.NumericUpDown priceNumeric;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label bidAsk;
    }
}