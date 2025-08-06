namespace KeePKCS11.Forms
{
    partial class FormEnterPIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnterPIN));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPinCode = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxDisplayPIN = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Enter your PIN:";
            // 
            // tbxPinCode
            // 
            this.tbxPinCode.Location = new System.Drawing.Point(20, 48);
            this.tbxPinCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPinCode.Name = "tbxPinCode";
            this.tbxPinCode.Size = new System.Drawing.Size(357, 22);
            this.tbxPinCode.TabIndex = 0;
            this.tbxPinCode.UseSystemPasswordChar = true;
            this.tbxPinCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPinCode_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(167, 114);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(275, 114);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxDisplayPIN
            // 
            this.checkBoxDisplayPIN.AutoSize = true;
            this.checkBoxDisplayPIN.Location = new System.Drawing.Point(20, 81);
            this.checkBoxDisplayPIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDisplayPIN.Name = "checkBoxDisplayPIN";
            this.checkBoxDisplayPIN.Size = new System.Drawing.Size(100, 20);
            this.checkBoxDisplayPIN.TabIndex = 1;
            this.checkBoxDisplayPIN.Text = "Display PIN";
            this.checkBoxDisplayPIN.UseVisualStyleBackColor = true;
            this.checkBoxDisplayPIN.CheckedChanged += new System.EventHandler(this.checkBoxDisplayPIN_CheckedChanged);
            // 
            // FormEnterPIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 170);
            this.Controls.Add(this.checkBoxDisplayPIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPinCode);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnterPIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter PIN code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPinCode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxDisplayPIN;
    }
}