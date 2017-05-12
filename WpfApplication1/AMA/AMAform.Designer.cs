namespace WpfApplication1.AMA
{
    partial class AMAform
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
            this.userAMAgroupBox = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.addLogicButton = new System.Windows.Forms.Button();
            this.userAmaString = new System.Windows.Forms.Button();
            this.userAMAbutton = new System.Windows.Forms.Button();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.userQueryButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.amaGroupBox = new System.Windows.Forms.GroupBox();
            this.amaString = new System.Windows.Forms.Button();
            this.amaButton = new System.Windows.Forms.Button();
            this.userAMAgroupBox.SuspendLayout();
            this.infoGroupBox.SuspendLayout();
            this.amaGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userAMAgroupBox
            // 
            this.userAMAgroupBox.Controls.Add(this.clearButton);
            this.userAMAgroupBox.Controls.Add(this.addLogicButton);
            this.userAMAgroupBox.Controls.Add(this.userAmaString);
            this.userAMAgroupBox.Controls.Add(this.userAMAbutton);
            this.userAMAgroupBox.Location = new System.Drawing.Point(14, 160);
            this.userAMAgroupBox.Name = "userAMAgroupBox";
            this.userAMAgroupBox.Size = new System.Drawing.Size(325, 140);
            this.userAMAgroupBox.TabIndex = 5;
            this.userAMAgroupBox.TabStop = false;
            this.userAMAgroupBox.Text = "User AMA";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(172, 84);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(93, 38);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear Rules";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // addLogicButton
            // 
            this.addLogicButton.Location = new System.Drawing.Point(172, 19);
            this.addLogicButton.Name = "addLogicButton";
            this.addLogicButton.Size = new System.Drawing.Size(93, 38);
            this.addLogicButton.TabIndex = 2;
            this.addLogicButton.Text = "Add Rule";
            this.addLogicButton.UseVisualStyleBackColor = true;
            // 
            // userAmaString
            // 
            this.userAmaString.Location = new System.Drawing.Point(57, 84);
            this.userAmaString.Name = "userAmaString";
            this.userAmaString.Size = new System.Drawing.Size(93, 38);
            this.userAmaString.TabIndex = 1;
            this.userAmaString.Text = "Current Logics";
            this.userAmaString.UseVisualStyleBackColor = true;
            // 
            // userAMAbutton
            // 
            this.userAMAbutton.Location = new System.Drawing.Point(57, 19);
            this.userAMAbutton.Name = "userAMAbutton";
            this.userAMAbutton.Size = new System.Drawing.Size(93, 38);
            this.userAMAbutton.TabIndex = 0;
            this.userAMAbutton.Text = "Run default AMA";
            this.userAMAbutton.UseVisualStyleBackColor = true;
            this.userAMAbutton.Click += new System.EventHandler(this.userAMAbutton_Click);
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.userQueryButton);
            this.infoGroupBox.Controls.Add(this.historyButton);
            this.infoGroupBox.Location = new System.Drawing.Point(189, 23);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(150, 114);
            this.infoGroupBox.TabIndex = 4;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Info";
            // 
            // userQueryButton
            // 
            this.userQueryButton.Location = new System.Drawing.Point(26, 19);
            this.userQueryButton.Name = "userQueryButton";
            this.userQueryButton.Size = new System.Drawing.Size(95, 38);
            this.userQueryButton.TabIndex = 2;
            this.userQueryButton.Text = "Current User Status";
            this.userQueryButton.UseVisualStyleBackColor = true;
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(26, 63);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(95, 38);
            this.historyButton.TabIndex = 3;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            // 
            // amaGroupBox
            // 
            this.amaGroupBox.Controls.Add(this.amaString);
            this.amaGroupBox.Controls.Add(this.amaButton);
            this.amaGroupBox.Location = new System.Drawing.Point(14, 23);
            this.amaGroupBox.Name = "amaGroupBox";
            this.amaGroupBox.Size = new System.Drawing.Size(150, 114);
            this.amaGroupBox.TabIndex = 3;
            this.amaGroupBox.TabStop = false;
            this.amaGroupBox.Text = "Default AMA";
            // 
            // amaString
            // 
            this.amaString.Location = new System.Drawing.Point(22, 63);
            this.amaString.Name = "amaString";
            this.amaString.Size = new System.Drawing.Size(93, 38);
            this.amaString.TabIndex = 1;
            this.amaString.Text = "Current Logics";
            this.amaString.UseVisualStyleBackColor = true;
            // 
            // amaButton
            // 
            this.amaButton.Location = new System.Drawing.Point(22, 19);
            this.amaButton.Name = "amaButton";
            this.amaButton.Size = new System.Drawing.Size(93, 38);
            this.amaButton.TabIndex = 0;
            this.amaButton.Text = "Run default AMA";
            this.amaButton.UseVisualStyleBackColor = true;
            // 
            // AMAform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 323);
            this.Controls.Add(this.userAMAgroupBox);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.amaGroupBox);
            this.Name = "AMAform";
            this.Text = "Autonomous Market Agent settings";
            this.Load += new System.EventHandler(this.AMAform_Load);
            this.userAMAgroupBox.ResumeLayout(false);
            this.infoGroupBox.ResumeLayout(false);
            this.amaGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userAMAgroupBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addLogicButton;
        private System.Windows.Forms.Button userAmaString;
        private System.Windows.Forms.Button userAMAbutton;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.GroupBox amaGroupBox;
        private System.Windows.Forms.Button amaString;
        private System.Windows.Forms.Button amaButton;
        private System.Windows.Forms.Button userQueryButton;
    }
}