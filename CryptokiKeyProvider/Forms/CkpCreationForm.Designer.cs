namespace CryptokiKeyProvider.Forms
{
    partial class CkpCreationForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReadKey = new System.Windows.Forms.Button();
            this.selectLibrary = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Slot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TokenName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDeleteKey = new System.Windows.Forms.Button();
            this.buttonImportKey = new System.Windows.Forms.Button();
            this.buttonExportKey = new System.Windows.Forms.Button();
            this.banner = new System.Windows.Forms.PictureBox();
            this.buttonCreateKey = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateUsingProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(479, 369);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(398, 369);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReadKey);
            this.groupBox1.Controls.Add(this.selectLibrary);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PKCS#11 Library Path";
            // 
            // buttonReadKey
            // 
            this.buttonReadKey.Location = new System.Drawing.Point(424, 17);
            this.buttonReadKey.Name = "buttonReadKey";
            this.buttonReadKey.Size = new System.Drawing.Size(111, 23);
            this.buttonReadKey.TabIndex = 9;
            this.buttonReadKey.Text = "Init/Read Keyfiles";
            this.buttonReadKey.UseVisualStyleBackColor = true;
            this.buttonReadKey.Click += new System.EventHandler(this.buttonReadKey_Click);
            // 
            // selectLibrary
            // 
            this.selectLibrary.Location = new System.Drawing.Point(324, 17);
            this.selectLibrary.Name = "selectLibrary";
            this.selectLibrary.Size = new System.Drawing.Size(94, 23);
            this.selectLibrary.TabIndex = 1;
            this.selectLibrary.Text = "Select Library...";
            this.selectLibrary.UseVisualStyleBackColor = true;
            this.selectLibrary.Click += new System.EventHandler(this.selectLibrary_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 20);
            this.textBox1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Slot,
            this.TokenName,
            this.Label});
            this.listView1.Enabled = false;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 122);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(542, 188);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChange);
            // 
            // Slot
            // 
            this.Slot.Text = "Slot";
            // 
            // TokenName
            // 
            this.TokenName.Text = "Token Name";
            this.TokenName.Width = 97;
            // 
            // Label
            // 
            this.Label.Text = "Label";
            // 
            // buttonDeleteKey
            // 
            this.buttonDeleteKey.Enabled = false;
            this.buttonDeleteKey.Location = new System.Drawing.Point(242, 316);
            this.buttonDeleteKey.Name = "buttonDeleteKey";
            this.buttonDeleteKey.Size = new System.Drawing.Size(99, 23);
            this.buttonDeleteKey.TabIndex = 6;
            this.buttonDeleteKey.Text = "Delete Keyfile";
            this.buttonDeleteKey.UseVisualStyleBackColor = true;
            this.buttonDeleteKey.Click += new System.EventHandler(this.buttonDeleteKey_Click);
            // 
            // buttonImportKey
            // 
            this.buttonImportKey.Enabled = false;
            this.buttonImportKey.Location = new System.Drawing.Point(455, 316);
            this.buttonImportKey.Name = "buttonImportKey";
            this.buttonImportKey.Size = new System.Drawing.Size(99, 23);
            this.buttonImportKey.TabIndex = 7;
            this.buttonImportKey.Text = "Import Keyfile";
            this.buttonImportKey.UseVisualStyleBackColor = true;
            this.buttonImportKey.Click += new System.EventHandler(this.buttonImportKey_Click);
            // 
            // buttonExportKey
            // 
            this.buttonExportKey.Enabled = false;
            this.buttonExportKey.Location = new System.Drawing.Point(347, 316);
            this.buttonExportKey.Name = "buttonExportKey";
            this.buttonExportKey.Size = new System.Drawing.Size(102, 23);
            this.buttonExportKey.TabIndex = 8;
            this.buttonExportKey.Text = "Export Keyfile";
            this.buttonExportKey.UseVisualStyleBackColor = true;
            this.buttonExportKey.Click += new System.EventHandler(this.buttonExportKey_Click);
            // 
            // banner
            // 
            this.banner.Dock = System.Windows.Forms.DockStyle.Top;
            this.banner.Location = new System.Drawing.Point(0, 0);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(566, 60);
            this.banner.TabIndex = 2;
            this.banner.TabStop = false;
            this.banner.Click += new System.EventHandler(this.banner_Click);
            // 
            // buttonCreateKey
            // 
            this.buttonCreateKey.Enabled = false;
            this.buttonCreateKey.Location = new System.Drawing.Point(12, 316);
            this.buttonCreateKey.Name = "buttonCreateKey";
            this.buttonCreateKey.Size = new System.Drawing.Size(89, 23);
            this.buttonCreateKey.TabIndex = 12;
            this.buttonCreateKey.Text = "Create Key";
            this.buttonCreateKey.UseVisualStyleBackColor = true;
            this.buttonCreateKey.Click += new System.EventHandler(this.buttonCreateKey_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test1ToolStripMenuItem,
            this.toolStripSeparator1,
            this.generateUsingProfileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 54);
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.test1ToolStripMenuItem.Text = "&Open Password Generator...";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.test1ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // generateUsingProfileToolStripMenuItem
            // 
            this.generateUsingProfileToolStripMenuItem.Name = "generateUsingProfileToolStripMenuItem";
            this.generateUsingProfileToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.generateUsingProfileToolStripMenuItem.Text = "Generate Using Profile";
            // 
            // CkpCreationForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(566, 405);
            this.Controls.Add(this.buttonCreateKey);
            this.Controls.Add(this.buttonExportKey);
            this.Controls.Add(this.buttonImportKey);
            this.Controls.Add(this.buttonDeleteKey);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.banner);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CkpCreationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "<>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox banner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectLibrary;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Slot;
        private System.Windows.Forms.ColumnHeader TokenName;
        private System.Windows.Forms.ColumnHeader Label;
        private System.Windows.Forms.Button buttonDeleteKey;
        private System.Windows.Forms.Button buttonImportKey;
        private System.Windows.Forms.Button buttonExportKey;
        private System.Windows.Forms.Button buttonReadKey;
        private System.Windows.Forms.Button buttonCreateKey;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem generateUsingProfileToolStripMenuItem;
    }
}