namespace KeePKCS11.Forms
{
    partial class FormConfirmKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfirmKey));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPinCode = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxDisplayPIN = new System.Windows.Forms.CheckBox();
            this.btnChangeKey = new System.Windows.Forms.Button();
            this.lblTokeSerialNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Enter your PIN:";
            // 
            // tbxPinCode
            // 
            this.tbxPinCode.Location = new System.Drawing.Point(15, 51);
            this.tbxPinCode.Name = "tbxPinCode";
            this.tbxPinCode.Size = new System.Drawing.Size(269, 20);
            this.tbxPinCode.TabIndex = 0;
            this.tbxPinCode.UseSystemPasswordChar = true;
            this.tbxPinCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPinCode_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(125, 126);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxDisplayPIN
            // 
            this.checkBoxDisplayPIN.AutoSize = true;
            this.checkBoxDisplayPIN.Location = new System.Drawing.Point(15, 78);
            this.checkBoxDisplayPIN.Name = "checkBoxDisplayPIN";
            this.checkBoxDisplayPIN.Size = new System.Drawing.Size(81, 17);
            this.checkBoxDisplayPIN.TabIndex = 15;
            this.checkBoxDisplayPIN.Text = "Display PIN";
            this.checkBoxDisplayPIN.UseVisualStyleBackColor = true;
            this.checkBoxDisplayPIN.CheckedChanged += new System.EventHandler(this.checkBoxDisplayPIN_CheckedChanged);
            // 
            // btnChangeKey
            // 
            this.btnChangeKey.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChangeKey.Location = new System.Drawing.Point(125, 97);
            this.btnChangeKey.Name = "btnChangeKey";
            this.btnChangeKey.Size = new System.Drawing.Size(156, 23);
            this.btnChangeKey.TabIndex = 16;
            this.btnChangeKey.Text = "&Change key";
            this.btnChangeKey.UseVisualStyleBackColor = true;
            this.btnChangeKey.Click += new System.EventHandler(this.btnChangeKey_Click);
            // 
            // lblTokeSerialNumber
            // 
            this.lblTokeSerialNumber.AutoSize = true;
            this.lblTokeSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTokeSerialNumber.Location = new System.Drawing.Point(12, 9);
            this.lblTokeSerialNumber.Name = "lblTokeSerialNumber";
            this.lblTokeSerialNumber.Size = new System.Drawing.Size(89, 16);
            this.lblTokeSerialNumber.TabIndex = 17;
            this.lblTokeSerialNumber.Text = "Token S/N: ";
            // 
            // FormConfirmKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 160);
            this.Controls.Add(this.lblTokeSerialNumber);
            this.Controls.Add(this.btnChangeKey);
            this.Controls.Add(this.checkBoxDisplayPIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPinCode);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirmKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter PIN code to get existing key";
            this.Load += new System.EventHandler(this.FormConfirmKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPinCode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxDisplayPIN;
        private System.Windows.Forms.Button btnChangeKey;
        private System.Windows.Forms.Label lblTokeSerialNumber;
    }
}