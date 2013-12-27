namespace BinAff.Tool.License
{
    partial class RegistrationChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationChecker));
            this.btnTest = new System.Windows.Forms.Button();
            this.txtAppFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowseAppFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgOpenApplicationFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cboSqlServerInstanceList = new System.Windows.Forms.ComboBox();
            this.lstDatabaseList = new System.Windows.Forms.ListBox();
            this.optRemote = new System.Windows.Forms.RadioButton();
            this.optLocal = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(482, 241);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(114, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtAppFolderPath
            // 
            this.txtAppFolderPath.Enabled = false;
            this.txtAppFolderPath.Location = new System.Drawing.Point(193, 12);
            this.txtAppFolderPath.Name = "txtAppFolderPath";
            this.txtAppFolderPath.Size = new System.Drawing.Size(403, 20);
            this.txtAppFolderPath.TabIndex = 9;
            // 
            // btnBrowseAppFolder
            // 
            this.btnBrowseAppFolder.Location = new System.Drawing.Point(106, 10);
            this.btnBrowseAppFolder.Name = "btnBrowseAppFolder";
            this.btnBrowseAppFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAppFolder.TabIndex = 8;
            this.btnBrowseAppFolder.Text = "Browse";
            this.btnBrowseAppFolder.UseVisualStyleBackColor = true;
            this.btnBrowseAppFolder.Click += new System.EventHandler(this.btnBrowseAppFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Product:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(106, 40);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(100, 20);
            this.txtProductName.TabIndex = 11;
            this.txtProductName.Text = "Splash";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(482, 212);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(114, 23);
            this.btnTestConnection.TabIndex = 21;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cboSqlServerInstanceList
            // 
            this.cboSqlServerInstanceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboSqlServerInstanceList.FormattingEnabled = true;
            this.cboSqlServerInstanceList.Location = new System.Drawing.Point(199, 66);
            this.cboSqlServerInstanceList.Name = "cboSqlServerInstanceList";
            this.cboSqlServerInstanceList.Size = new System.Drawing.Size(277, 98);
            this.cboSqlServerInstanceList.Sorted = true;
            this.cboSqlServerInstanceList.TabIndex = 20;
            this.cboSqlServerInstanceList.SelectedIndexChanged += new System.EventHandler(this.cboSqlServerInstanceList_SelectedIndexChanged);
            // 
            // lstDatabaseList
            // 
            this.lstDatabaseList.FormattingEnabled = true;
            this.lstDatabaseList.Location = new System.Drawing.Point(199, 170);
            this.lstDatabaseList.Name = "lstDatabaseList";
            this.lstDatabaseList.Size = new System.Drawing.Size(277, 95);
            this.lstDatabaseList.TabIndex = 19;
            // 
            // optRemote
            // 
            this.optRemote.AutoSize = true;
            this.optRemote.Location = new System.Drawing.Point(131, 92);
            this.optRemote.Name = "optRemote";
            this.optRemote.Size = new System.Drawing.Size(62, 17);
            this.optRemote.TabIndex = 18;
            this.optRemote.Text = "Remote";
            this.optRemote.UseVisualStyleBackColor = true;
            this.optRemote.CheckedChanged += new System.EventHandler(this.optRemote_CheckedChanged);
            // 
            // optLocal
            // 
            this.optLocal.AutoSize = true;
            this.optLocal.Location = new System.Drawing.Point(131, 69);
            this.optLocal.Name = "optLocal";
            this.optLocal.Size = new System.Drawing.Size(51, 17);
            this.optLocal.TabIndex = 17;
            this.optLocal.Text = "Local";
            this.optLocal.UseVisualStyleBackColor = true;
            this.optLocal.CheckedChanged += new System.EventHandler(this.optLocal_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Available Databases";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "SQL Server Instances";
            // 
            // RegistrationChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 277);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.cboSqlServerInstanceList);
            this.Controls.Add(this.lstDatabaseList);
            this.Controls.Add(this.optRemote);
            this.Controls.Add(this.optLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAppFolderPath);
            this.Controls.Add(this.btnBrowseAppFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationChecker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtAppFolderPath;
        private System.Windows.Forms.Button btnBrowseAppFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog dlgOpenApplicationFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.ComboBox cboSqlServerInstanceList;
        private System.Windows.Forms.ListBox lstDatabaseList;
        private System.Windows.Forms.RadioButton optRemote;
        private System.Windows.Forms.RadioButton optLocal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}