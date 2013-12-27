namespace BinAff.Tool.License
{
    partial class FingurePrintManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingurePrintManager));
            this.btnLicenseMachine = new System.Windows.Forms.Button();
            this.dlgOpenLicenseFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseLicsFile = new System.Windows.Forms.Button();
            this.txtLicsFilePath = new System.Windows.Forms.TextBox();
            this.txtAppFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowseAppFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgOpenApplicationFile = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.optLocal = new System.Windows.Forms.RadioButton();
            this.optRemote = new System.Windows.Forms.RadioButton();
            this.lstDatabaseList = new System.Windows.Forms.ListBox();
            this.cboSqlServerInstanceList = new System.Windows.Forms.ComboBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLicenseMachine
            // 
            this.btnLicenseMachine.Enabled = false;
            this.btnLicenseMachine.Location = new System.Drawing.Point(550, 285);
            this.btnLicenseMachine.Name = "btnLicenseMachine";
            this.btnLicenseMachine.Size = new System.Drawing.Size(114, 23);
            this.btnLicenseMachine.TabIndex = 0;
            this.btnLicenseMachine.Text = "Insert Fingure Print";
            this.btnLicenseMachine.UseVisualStyleBackColor = true;
            this.btnLicenseMachine.Click += new System.EventHandler(this.btnLicenseMachine_Click);
            // 
            // dlgOpenLicenseFile
            // 
            this.dlgOpenLicenseFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgOpenLicenseFile_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Open License File:";
            // 
            // btnBrowseLicsFile
            // 
            this.btnBrowseLicsFile.Location = new System.Drawing.Point(110, 15);
            this.btnBrowseLicsFile.Name = "btnBrowseLicsFile";
            this.btnBrowseLicsFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLicsFile.TabIndex = 2;
            this.btnBrowseLicsFile.Text = "Browse";
            this.btnBrowseLicsFile.UseVisualStyleBackColor = true;
            this.btnBrowseLicsFile.Click += new System.EventHandler(this.btnBrowseLicsFile_Click);
            // 
            // txtLicsFilePath
            // 
            this.txtLicsFilePath.Enabled = false;
            this.txtLicsFilePath.Location = new System.Drawing.Point(197, 17);
            this.txtLicsFilePath.Name = "txtLicsFilePath";
            this.txtLicsFilePath.Size = new System.Drawing.Size(467, 20);
            this.txtLicsFilePath.TabIndex = 3;
            // 
            // txtAppFolderPath
            // 
            this.txtAppFolderPath.Enabled = false;
            this.txtAppFolderPath.Location = new System.Drawing.Point(197, 50);
            this.txtAppFolderPath.Name = "txtAppFolderPath";
            this.txtAppFolderPath.Size = new System.Drawing.Size(467, 20);
            this.txtAppFolderPath.TabIndex = 6;
            // 
            // btnBrowseAppFolder
            // 
            this.btnBrowseAppFolder.Location = new System.Drawing.Point(110, 48);
            this.btnBrowseAppFolder.Name = "btnBrowseAppFolder";
            this.btnBrowseAppFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAppFolder.TabIndex = 5;
            this.btnBrowseAppFolder.Text = "Browse";
            this.btnBrowseAppFolder.UseVisualStyleBackColor = true;
            this.btnBrowseAppFolder.Click += new System.EventHandler(this.btnBrowseAppFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Product:";
            // 
            // dlgOpenApplicationFile
            // 
            this.dlgOpenApplicationFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgOpenApplicationFile_FileOk);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "SQL Server Instances";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Available Databases";
            // 
            // optLocal
            // 
            this.optLocal.AutoSize = true;
            this.optLocal.Location = new System.Drawing.Point(134, 112);
            this.optLocal.Name = "optLocal";
            this.optLocal.Size = new System.Drawing.Size(51, 17);
            this.optLocal.TabIndex = 10;
            this.optLocal.Text = "Local";
            this.optLocal.UseVisualStyleBackColor = true;
            this.optLocal.CheckedChanged += new System.EventHandler(this.optLocal_CheckedChanged);
            // 
            // optRemote
            // 
            this.optRemote.AutoSize = true;
            this.optRemote.Location = new System.Drawing.Point(134, 135);
            this.optRemote.Name = "optRemote";
            this.optRemote.Size = new System.Drawing.Size(62, 17);
            this.optRemote.TabIndex = 11;
            this.optRemote.Text = "Remote";
            this.optRemote.UseVisualStyleBackColor = true;
            this.optRemote.CheckedChanged += new System.EventHandler(this.optRemote_CheckedChanged);
            // 
            // lstDatabaseList
            // 
            this.lstDatabaseList.FormattingEnabled = true;
            this.lstDatabaseList.Location = new System.Drawing.Point(202, 213);
            this.lstDatabaseList.Name = "lstDatabaseList";
            this.lstDatabaseList.Size = new System.Drawing.Size(277, 95);
            this.lstDatabaseList.TabIndex = 12;
            // 
            // cboSqlServerInstanceList
            // 
            this.cboSqlServerInstanceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboSqlServerInstanceList.FormattingEnabled = true;
            this.cboSqlServerInstanceList.Location = new System.Drawing.Point(202, 109);
            this.cboSqlServerInstanceList.Name = "cboSqlServerInstanceList";
            this.cboSqlServerInstanceList.Size = new System.Drawing.Size(277, 98);
            this.cboSqlServerInstanceList.Sorted = true;
            this.cboSqlServerInstanceList.TabIndex = 13;
            this.cboSqlServerInstanceList.SelectedIndexChanged += new System.EventHandler(this.cboSqlServerInstanceList_SelectedIndexChanged);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(550, 254);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(114, 23);
            this.btnTestConnection.TabIndex = 14;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 319);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.cboSqlServerInstanceList);
            this.Controls.Add(this.lstDatabaseList);
            this.Controls.Add(this.optRemote);
            this.Controls.Add(this.optLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAppFolderPath);
            this.Controls.Add(this.btnBrowseAppFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicsFilePath);
            this.Controls.Add(this.btnBrowseLicsFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLicenseMachine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fingure Print Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLicenseMachine;
        private System.Windows.Forms.OpenFileDialog dlgOpenLicenseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseLicsFile;
        private System.Windows.Forms.TextBox txtLicsFilePath;
        private System.Windows.Forms.TextBox txtAppFolderPath;
        private System.Windows.Forms.Button btnBrowseAppFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog dlgOpenApplicationFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton optLocal;
        private System.Windows.Forms.RadioButton optRemote;
        private System.Windows.Forms.ListBox lstDatabaseList;
        private System.Windows.Forms.ComboBox cboSqlServerInstanceList;
        private System.Windows.Forms.Button btnTestConnection;
    }
}

