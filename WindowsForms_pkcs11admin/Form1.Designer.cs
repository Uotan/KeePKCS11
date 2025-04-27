namespace WindowsForms_pkcs11admin
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetLibraryInfo = new System.Windows.Forms.Button();
            this.tbxLibraryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLibraryManufacturer = new System.Windows.Forms.Label();
            this.lblLibraryVersion = new System.Windows.Forms.Label();
            this.lblCryptokiVersion = new System.Windows.Forms.Label();
            this.gridSlots = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetLibraryInfo
            // 
            this.btnGetLibraryInfo.Location = new System.Drawing.Point(415, 32);
            this.btnGetLibraryInfo.Name = "btnGetLibraryInfo";
            this.btnGetLibraryInfo.Size = new System.Drawing.Size(116, 23);
            this.btnGetLibraryInfo.TabIndex = 0;
            this.btnGetLibraryInfo.Text = "Get library info/slots";
            this.btnGetLibraryInfo.UseVisualStyleBackColor = true;
            this.btnGetLibraryInfo.Click += new System.EventHandler(this.btnGetLibraryInfo_Click);
            // 
            // tbxLibraryPath
            // 
            this.tbxLibraryPath.Location = new System.Drawing.Point(127, 35);
            this.tbxLibraryPath.Name = "tbxLibraryPath";
            this.tbxLibraryPath.Size = new System.Drawing.Size(282, 20);
            this.tbxLibraryPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set the path to the pkcs#11 library";
            // 
            // lblLibraryManufacturer
            // 
            this.lblLibraryManufacturer.AutoSize = true;
            this.lblLibraryManufacturer.Location = new System.Drawing.Point(124, 63);
            this.lblLibraryManufacturer.Name = "lblLibraryManufacturer";
            this.lblLibraryManufacturer.Size = new System.Drawing.Size(73, 13);
            this.lblLibraryManufacturer.TabIndex = 3;
            this.lblLibraryManufacturer.Text = "Manufacturer:";
            this.lblLibraryManufacturer.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblLibraryVersion
            // 
            this.lblLibraryVersion.AutoSize = true;
            this.lblLibraryVersion.Location = new System.Drawing.Point(124, 86);
            this.lblLibraryVersion.Name = "lblLibraryVersion";
            this.lblLibraryVersion.Size = new System.Drawing.Size(83, 13);
            this.lblLibraryVersion.TabIndex = 4;
            this.lblLibraryVersion.Text = "Library versions:";
            // 
            // lblCryptokiVersion
            // 
            this.lblCryptokiVersion.AutoSize = true;
            this.lblCryptokiVersion.Location = new System.Drawing.Point(124, 110);
            this.lblCryptokiVersion.Name = "lblCryptokiVersion";
            this.lblCryptokiVersion.Size = new System.Drawing.Size(89, 13);
            this.lblCryptokiVersion.TabIndex = 5;
            this.lblCryptokiVersion.Text = "pkcs#11 version:";
            // 
            // gridSlots
            // 
            this.gridSlots.AllowUserToAddRows = false;
            this.gridSlots.AllowUserToDeleteRows = false;
            this.gridSlots.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridSlots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSlots.Location = new System.Drawing.Point(15, 136);
            this.gridSlots.MultiSelect = false;
            this.gridSlots.Name = "gridSlots";
            this.gridSlots.ReadOnly = true;
            this.gridSlots.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSlots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSlots.Size = new System.Drawing.Size(516, 302);
            this.gridSlots.StandardTab = true;
            this.gridSlots.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsForms_pkcs11admin.Properties.Resources.pkcs11_token;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gridSlots);
            this.Controls.Add(this.lblCryptokiVersion);
            this.Controls.Add(this.lblLibraryVersion);
            this.Controls.Add(this.lblLibraryManufacturer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxLibraryPath);
            this.Controls.Add(this.btnGetLibraryInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pkcs#11 test editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetLibraryInfo;
        private System.Windows.Forms.TextBox tbxLibraryPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLibraryManufacturer;
        private System.Windows.Forms.Label lblLibraryVersion;
        private System.Windows.Forms.Label lblCryptokiVersion;
        private System.Windows.Forms.DataGridView gridSlots;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

