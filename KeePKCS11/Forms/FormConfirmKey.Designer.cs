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
            this.lblTokeModel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Enter your PIN:";
            // 
            // tbxPinCode
            // 
            this.tbxPinCode.Location = new System.Drawing.Point(15, 96);
            this.tbxPinCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPinCode.Name = "tbxPinCode";
            this.tbxPinCode.Size = new System.Drawing.Size(357, 22);
            this.tbxPinCode.TabIndex = 0;
            this.tbxPinCode.UseSystemPasswordChar = true;
            this.tbxPinCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxPinCode_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(162, 188);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 188);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxDisplayPIN
            // 
            this.checkBoxDisplayPIN.AutoSize = true;
            this.checkBoxDisplayPIN.Location = new System.Drawing.Point(15, 129);
            this.checkBoxDisplayPIN.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDisplayPIN.Name = "checkBoxDisplayPIN";
            this.checkBoxDisplayPIN.Size = new System.Drawing.Size(100, 20);
            this.checkBoxDisplayPIN.TabIndex = 1;
            this.checkBoxDisplayPIN.Text = "Display PIN";
            this.checkBoxDisplayPIN.UseVisualStyleBackColor = true;
            this.checkBoxDisplayPIN.CheckedChanged += new System.EventHandler(this.checkBoxDisplayPIN_CheckedChanged);
            // 
            // btnChangeKey
            // 
            this.btnChangeKey.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChangeKey.Location = new System.Drawing.Point(162, 152);
            this.btnChangeKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeKey.Name = "btnChangeKey";
            this.btnChangeKey.Size = new System.Drawing.Size(208, 28);
            this.btnChangeKey.TabIndex = 2;
            this.btnChangeKey.Text = "&Change key";
            this.btnChangeKey.UseVisualStyleBackColor = true;
            this.btnChangeKey.Click += new System.EventHandler(this.btnChangeKey_Click);
            // 
            // lblTokeSerialNumber
            // 
            this.lblTokeSerialNumber.AutoSize = true;
            this.lblTokeSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTokeSerialNumber.Location = new System.Drawing.Point(11, 11);
            this.lblTokeSerialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTokeSerialNumber.Name = "lblTokeSerialNumber";
            this.lblTokeSerialNumber.Size = new System.Drawing.Size(108, 20);
            this.lblTokeSerialNumber.TabIndex = 17;
            this.lblTokeSerialNumber.Text = "Token S/N: ";
            // 
            // lblTokeModel
            // 
            this.lblTokeModel.AutoSize = true;
            this.lblTokeModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTokeModel.Location = new System.Drawing.Point(11, 43);
            this.lblTokeModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTokeModel.Name = "lblTokeModel";
            this.lblTokeModel.Size = new System.Drawing.Size(127, 20);
            this.lblTokeModel.TabIndex = 18;
            this.lblTokeModel.Text = "Token Model: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeePKCS11.Properties.Resources.pkcs11_token;
            this.pictureBox1.Location = new System.Drawing.Point(14, 152);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // FormConfirmKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 229);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTokeModel);
            this.Controls.Add(this.lblTokeSerialNumber);
            this.Controls.Add(this.btnChangeKey);
            this.Controls.Add(this.checkBoxDisplayPIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPinCode);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfirmKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter PIN code to get existing key";
            this.Load += new System.EventHandler(this.FormConfirmKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblTokeModel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}