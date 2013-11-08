namespace QuickPrintDrawings
{
    partial class button1
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
            this.btnShow = new System.Windows.Forms.Button();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.chkDWG = new System.Windows.Forms.CheckBox();
            this.rbtn11 = new System.Windows.Forms.RadioButton();
            this.rbtnSCALE = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(245, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(82, 28);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Write";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Checked = true;
            this.chkPDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPDF.Location = new System.Drawing.Point(12, 12);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(47, 17);
            this.chkPDF.TabIndex = 1;
            this.chkPDF.Text = "PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // chkDWG
            // 
            this.chkDWG.AutoSize = true;
            this.chkDWG.Checked = true;
            this.chkDWG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDWG.Location = new System.Drawing.Point(65, 12);
            this.chkDWG.Name = "chkDWG";
            this.chkDWG.Size = new System.Drawing.Size(53, 17);
            this.chkDWG.TabIndex = 2;
            this.chkDWG.Text = "DWG";
            this.chkDWG.UseVisualStyleBackColor = true;
            // 
            // rbtn11
            // 
            this.rbtn11.AutoSize = true;
            this.rbtn11.Checked = true;
            this.rbtn11.Location = new System.Drawing.Point(124, 12);
            this.rbtn11.Name = "rbtn11";
            this.rbtn11.Size = new System.Drawing.Size(40, 17);
            this.rbtn11.TabIndex = 3;
            this.rbtn11.TabStop = true;
            this.rbtn11.Text = "1:1";
            this.rbtn11.UseVisualStyleBackColor = true;
            // 
            // rbtnSCALE
            // 
            this.rbtnSCALE.AutoSize = true;
            this.rbtnSCALE.Location = new System.Drawing.Point(170, 11);
            this.rbtnSCALE.Name = "rbtnSCALE";
            this.rbtnSCALE.Size = new System.Drawing.Size(73, 17);
            this.rbtnSCALE.TabIndex = 4;
            this.rbtnSCALE.Text = "From view";
            this.rbtnSCALE.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 39);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(315, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 69);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "label1";
            // 
            // button1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(339, 91);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkDWG);
            this.Controls.Add(this.rbtn11);
            this.Controls.Add(this.chkPDF);
            this.Controls.Add(this.rbtnSCALE);
            this.Controls.Add(this.btnShow);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "button1";
            this.Text = "Quick print drawings - (c) Hopia 2012";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Windows.Forms.CheckBox chkDWG;
        private System.Windows.Forms.RadioButton rbtn11;
        private System.Windows.Forms.RadioButton rbtnSCALE;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMessage;
    }
}

