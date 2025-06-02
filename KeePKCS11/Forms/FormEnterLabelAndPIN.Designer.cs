namespace KeePKCS11.Forms
{
    partial class FormEnterLabelAndPIN
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
            this.checkBoxDisplayPIN = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPinCode = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxObjectLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxDisplayPIN
            // 
            this.checkBoxDisplayPIN.AutoSize = true;
            this.checkBoxDisplayPIN.Location = new System.Drawing.Point(18, 133);
            this.checkBoxDisplayPIN.Name = "checkBoxDisplayPIN";
            this.checkBoxDisplayPIN.Size = new System.Drawing.Size(81, 17);
            this.checkBoxDisplayPIN.TabIndex = 20;
            this.checkBoxDisplayPIN.Text = "Display PIN";
            this.checkBoxDisplayPIN.UseVisualStyleBackColor = true;
            this.checkBoxDisplayPIN.CheckedChanged += new System.EventHandler(this.checkBoxDisplayPIN_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter your PIN:";
            // 
            // tbxPinCode
            // 
            this.tbxPinCode.Location = new System.Drawing.Point(18, 106);
            this.tbxPinCode.Name = "tbxPinCode";
            this.tbxPinCode.Size = new System.Drawing.Size(269, 20);
            this.tbxPinCode.TabIndex = 16;
            this.tbxPinCode.UseSystemPasswordChar = true;
            this.tbxPinCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPinCode_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(128, 160);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(209, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Enter object label:";
            // 
            // tbxObjectLabel
            // 
            this.tbxObjectLabel.Location = new System.Drawing.Point(18, 57);
            this.tbxObjectLabel.Name = "tbxObjectLabel";
            this.tbxObjectLabel.Size = new System.Drawing.Size(269, 20);
            this.tbxObjectLabel.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "( leave this field empty to create it automatically )";
            // 
            // FormEnterLabelAndPIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 205);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxObjectLabel);
            this.Controls.Add(this.checkBoxDisplayPIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPinCode);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnterLabelAndPIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter object label";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxDisplayPIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPinCode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxObjectLabel;
        private System.Windows.Forms.Label label3;
    }
}