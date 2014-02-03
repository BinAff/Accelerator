namespace BinAff.Tool.Installer
{
    partial class ApplicationConfiguration
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSqlServerInstanceList = new System.Windows.Forms.ComboBox();
            this.optRemote = new System.Windows.Forms.RadioButton();
            this.optLocal = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.optSQLServer = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.optWindows = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(112, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(193, 14);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(385, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(503, 336);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(422, 336);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Application Folder:";
            // 
            // cboSqlServerInstanceList
            // 
            this.cboSqlServerInstanceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboSqlServerInstanceList.FormattingEnabled = true;
            this.cboSqlServerInstanceList.Location = new System.Drawing.Point(136, 84);
            this.cboSqlServerInstanceList.Name = "cboSqlServerInstanceList";
            this.cboSqlServerInstanceList.Size = new System.Drawing.Size(171, 111);
            this.cboSqlServerInstanceList.Sorted = true;
            this.cboSqlServerInstanceList.TabIndex = 25;
            // 
            // optRemote
            // 
            this.optRemote.AutoSize = true;
            this.optRemote.Location = new System.Drawing.Point(193, 61);
            this.optRemote.Name = "optRemote";
            this.optRemote.Size = new System.Drawing.Size(62, 17);
            this.optRemote.TabIndex = 24;
            this.optRemote.Text = "Remote";
            this.optRemote.UseVisualStyleBackColor = true;
            this.optRemote.CheckedChanged += new System.EventHandler(this.optRemote_CheckedChanged);
            // 
            // optLocal
            // 
            this.optLocal.AutoSize = true;
            this.optLocal.Location = new System.Drawing.Point(136, 61);
            this.optLocal.Name = "optLocal";
            this.optLocal.Size = new System.Drawing.Size(51, 17);
            this.optLocal.TabIndex = 23;
            this.optLocal.Text = "Local";
            this.optLocal.UseVisualStyleBackColor = true;
            this.optLocal.CheckedChanged += new System.EventHandler(this.optLocal_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "SQL Server Instances";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(422, 271);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(156, 23);
            this.btnTestConnection.TabIndex = 35;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.optSQLServer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.optWindows);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(136, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 106);
            this.panel1.TabIndex = 36;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(79, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 38;
            // 
            // optSQLServer
            // 
            this.optSQLServer.AutoSize = true;
            this.optSQLServer.Location = new System.Drawing.Point(13, 27);
            this.optSQLServer.Name = "optSQLServer";
            this.optSQLServer.Size = new System.Drawing.Size(151, 17);
            this.optSQLServer.TabIndex = 40;
            this.optSQLServer.Text = "SQL Server Authentication";
            this.optSQLServer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(79, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(199, 20);
            this.txtUserName.TabIndex = 37;
            // 
            // optWindows
            // 
            this.optWindows.AutoSize = true;
            this.optWindows.Checked = true;
            this.optWindows.Location = new System.Drawing.Point(13, 4);
            this.optWindows.Name = "optWindows";
            this.optWindows.Size = new System.Drawing.Size(140, 17);
            this.optWindows.TabIndex = 39;
            this.optWindows.TabStop = true;
            this.optWindows.Text = "Windows Authentication";
            this.optWindows.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "User Name:";
            // 
            // ApplicationConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 371);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.cboSqlServerInstanceList);
            this.Controls.Add(this.optRemote);
            this.Controls.Add(this.optLocal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ApplicationConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Configuration";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSqlServerInstanceList;
        private System.Windows.Forms.RadioButton optRemote;
        private System.Windows.Forms.RadioButton optLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RadioButton optSQLServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.RadioButton optWindows;
        private System.Windows.Forms.Label label4;
    }
}