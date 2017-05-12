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
            this.amountNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.commodityNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.priceNumeric = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // buyRadioButton
            // 
            this.buyRadioButton.AutoSize = true;
            this.buyRadioButton.Checked = true;
            this.buyRadioButton.Location = new System.Drawing.Point(13, 20);
            this.buyRadioButton.Name = "buyRadioButton";
            this.buyRadioButton.Size = new System.Drawing.Size(43, 17);
            this.buyRadioButton.TabIndex = 0;
            this.buyRadioButton.TabStop = true;
            this.buyRadioButton.Text = "Buy";
            this.buyRadioButton.UseVisualStyleBackColor = true;
            // 
            // SellRadioButton
            // 
            this.SellRadioButton.AutoSize = true;
            this.SellRadioButton.Location = new System.Drawing.Point(13, 43);
            this.SellRadioButton.Name = "SellRadioButton";
            this.SellRadioButton.Size = new System.Drawing.Size(42, 17);
            this.SellRadioButton.TabIndex = 1;
            this.SellRadioButton.Text = "Sell";
            this.SellRadioButton.UseVisualStyleBackColor = true;
            // 
            // amountNumeric
            // 
            this.amountNumeric.Location = new System.Drawing.Point(62, 29);
            this.amountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountNumeric.Name = "amountNumeric";
            this.amountNumeric.Size = new System.Drawing.Size(68, 20);
            this.amountNumeric.TabIndex = 2;
            this.amountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "of commodity";
            // 
            // commodityNumeric
            // 
            this.commodityNumeric.Location = new System.Drawing.Point(211, 29);
            this.commodityNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.commodityNumeric.Name = "commodityNumeric";
            this.commodityNumeric.Size = new System.Drawing.Size(44, 20);
            this.commodityNumeric.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "when the price is equal or";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "below";
            // 
            // priceNumeric
            // 
            this.priceNumeric.Location = new System.Drawing.Point(181, 83);
            this.priceNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.priceNumeric.Name = "priceNumeric";
            this.priceNumeric.Size = new System.Drawing.Size(57, 20);
            this.priceNumeric.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(271, 80);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add Rule";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddLogicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 136);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.priceNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commodityNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amountNumeric);
            this.Controls.Add(this.SellRadioButton);
            this.Controls.Add(this.buyRadioButton);
            this.Name = "AddLogicForm";
            this.Text = "Add User Rules";
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton buyRadioButton;
        private System.Windows.Forms.RadioButton SellRadioButton;
        private System.Windows.Forms.NumericUpDown amountNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown commodityNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown priceNumeric;
        private System.Windows.Forms.Button addButton;
    }
}