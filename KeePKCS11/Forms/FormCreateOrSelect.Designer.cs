namespace KeePKCS11.Forms
{
    partial class FormCreateOrSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateOrSelect));
            this.btnGetLibraryInfo = new System.Windows.Forms.Button();
            this.tbxLibraryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLibraryManufacturer = new System.Windows.Forms.Label();
            this.lblLibraryVersion = new System.Windows.Forms.Label();
            this.lblCryptokiVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewTokens = new System.Windows.Forms.ListView();
            this.SlotId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SerialNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TokenModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TokenLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDataObjects = new System.Windows.Forms.ListView();
            this.ObjectLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReadTokenData = new System.Windows.Forms.Button();
            this.btnCreateKey = new System.Windows.Forms.Button();
            this.btnSelectKey = new System.Windows.Forms.Button();
            this.btnSelectLibrary = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetLibraryInfo
            // 
            this.btnGetLibraryInfo.Enabled = false;
            this.btnGetLibraryInfo.Location = new System.Drawing.Point(415, 32);
            this.btnGetLibraryInfo.Name = "btnGetLibraryInfo";
            this.btnGetLibraryInfo.Size = new System.Drawing.Size(116, 23);
            this.btnGetLibraryInfo.TabIndex = 0;
            this.btnGetLibraryInfo.Text = "Get/Update info";
            this.btnGetLibraryInfo.UseVisualStyleBackColor = true;
            this.btnGetLibraryInfo.Click += new System.EventHandler(this.btnGetLibraryInfo_Click);
            // 
            // tbxLibraryPath
            // 
            this.tbxLibraryPath.Location = new System.Drawing.Point(159, 35);
            this.tbxLibraryPath.Name = "tbxLibraryPath";
            this.tbxLibraryPath.Size = new System.Drawing.Size(250, 20);
            this.tbxLibraryPath.TabIndex = 0;
            this.tbxLibraryPath.TextChanged += new System.EventHandler(this.tbxLibraryPath_TextChanged);
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
            this.lblCryptokiVersion.Size = new System.Drawing.Size(94, 13);
            this.lblCryptokiVersion.TabIndex = 5;
            this.lblCryptokiVersion.Text = "PKCS#11 version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Slots:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data objects (key files)";
            // 
            // listViewTokens
            // 
            this.listViewTokens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SlotId,
            this.SerialNumber,
            this.TokenModel,
            this.TokenLabel});
            this.listViewTokens.FullRowSelect = true;
            this.listViewTokens.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTokens.HideSelection = false;
            this.listViewTokens.LabelWrap = false;
            this.listViewTokens.Location = new System.Drawing.Point(12, 153);
            this.listViewTokens.MultiSelect = false;
            this.listViewTokens.Name = "listViewTokens";
            this.listViewTokens.Size = new System.Drawing.Size(518, 144);
            this.listViewTokens.TabIndex = 8;
            this.listViewTokens.UseCompatibleStateImageBehavior = false;
            this.listViewTokens.View = System.Windows.Forms.View.Details;
            // 
            // SlotId
            // 
            this.SlotId.Text = "Slot ID";
            this.SlotId.Width = 74;
            // 
            // SerialNumber
            // 
            this.SerialNumber.Text = "Serial Number";
            this.SerialNumber.Width = 141;
            // 
            // TokenModel
            // 
            this.TokenModel.Text = "Token Model";
            this.TokenModel.Width = 91;
            // 
            // TokenLabel
            // 
            this.TokenLabel.Text = "Token Label";
            this.TokenLabel.Width = 208;
            // 
            // listViewDataObjects
            // 
            this.listViewDataObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ObjectLabel});
            this.listViewDataObjects.FullRowSelect = true;
            this.listViewDataObjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDataObjects.HideSelection = false;
            this.listViewDataObjects.LabelWrap = false;
            this.listViewDataObjects.Location = new System.Drawing.Point(12, 341);
            this.listViewDataObjects.MultiSelect = false;
            this.listViewDataObjects.Name = "listViewDataObjects";
            this.listViewDataObjects.Size = new System.Drawing.Size(518, 144);
            this.listViewDataObjects.TabIndex = 12;
            this.listViewDataObjects.UseCompatibleStateImageBehavior = false;
            this.listViewDataObjects.View = System.Windows.Forms.View.Details;
            // 
            // ObjectLabel
            // 
            this.ObjectLabel.Text = "Label";
            this.ObjectLabel.Width = 300;
            // 
            // btnReadTokenData
            // 
            this.btnReadTokenData.Enabled = false;
            this.btnReadTokenData.Location = new System.Drawing.Point(414, 303);
            this.btnReadTokenData.Name = "btnReadTokenData";
            this.btnReadTokenData.Size = new System.Drawing.Size(116, 23);
            this.btnReadTokenData.TabIndex = 13;
            this.btnReadTokenData.Text = "Read keyfiles";
            this.btnReadTokenData.UseVisualStyleBackColor = true;
            this.btnReadTokenData.Click += new System.EventHandler(this.btnReadTokenData_Click);
            // 
            // btnCreateKey
            // 
            this.btnCreateKey.Enabled = false;
            this.btnCreateKey.Location = new System.Drawing.Point(12, 491);
            this.btnCreateKey.Name = "btnCreateKey";
            this.btnCreateKey.Size = new System.Drawing.Size(75, 23);
            this.btnCreateKey.TabIndex = 14;
            this.btnCreateKey.Text = "Create key";
            this.btnCreateKey.UseVisualStyleBackColor = true;
            this.btnCreateKey.Click += new System.EventHandler(this.btnCreateKey_Click);
            // 
            // btnSelectKey
            // 
            this.btnSelectKey.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelectKey.Enabled = false;
            this.btnSelectKey.Location = new System.Drawing.Point(415, 491);
            this.btnSelectKey.Name = "btnSelectKey";
            this.btnSelectKey.Size = new System.Drawing.Size(115, 23);
            this.btnSelectKey.TabIndex = 15;
            this.btnSelectKey.Text = "Select key";
            this.btnSelectKey.UseVisualStyleBackColor = true;
            this.btnSelectKey.Click += new System.EventHandler(this.btnSelectKey_Click);
            // 
            // btnSelectLibrary
            // 
            this.btnSelectLibrary.Location = new System.Drawing.Point(127, 33);
            this.btnSelectLibrary.Name = "btnSelectLibrary";
            this.btnSelectLibrary.Size = new System.Drawing.Size(26, 23);
            this.btnSelectLibrary.TabIndex = 16;
            this.btnSelectLibrary.Text = "...";
            this.btnSelectLibrary.UseVisualStyleBackColor = true;
            this.btnSelectLibrary.Click += new System.EventHandler(this.btnSelectLibrary_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KeePKCS11.Properties.Resources.pkcs11_token;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FormCreateOrSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 522);
            this.Controls.Add(this.btnSelectLibrary);
            this.Controls.Add(this.btnSelectKey);
            this.Controls.Add(this.btnCreateKey);
            this.Controls.Add(this.btnReadTokenData);
            this.Controls.Add(this.listViewDataObjects);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewTokens);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCryptokiVersion);
            this.Controls.Add(this.lblLibraryVersion);
            this.Controls.Add(this.lblLibraryManufacturer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxLibraryPath);
            this.Controls.Add(this.btnGetLibraryInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCreateOrSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeePKCS11";
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewTokens;
        private System.Windows.Forms.ListView listViewDataObjects;
        private System.Windows.Forms.ColumnHeader SlotId;
        private System.Windows.Forms.ColumnHeader SerialNumber;
        private System.Windows.Forms.ColumnHeader TokenModel;
        private System.Windows.Forms.ColumnHeader TokenLabel;
        private System.Windows.Forms.Button btnReadTokenData;
        private System.Windows.Forms.ColumnHeader ObjectLabel;
        private System.Windows.Forms.Button btnCreateKey;
        private System.Windows.Forms.Button btnSelectKey;
        private System.Windows.Forms.Button btnSelectLibrary;
    }
}

