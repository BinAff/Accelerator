namespace BinAff.Tool.Installer
{
    partial class DatabaseConfiguration
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cboSqlServerInstanceList = new System.Windows.Forms.ComboBox();
            this.lstDatabaseList = new System.Windows.Forms.ListBox();
            this.optRemote = new System.Windows.Forms.RadioButton();
            this.optLocal = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optSQLServer = new System.Windows.Forms.RadioButton();
            this.optWindows = new System.Windows.Forms.RadioButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 357);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(468, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(405, 386);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(366, 328);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(114, 23);
            this.btnTestConnection.TabIndex = 22;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cboSqlServerInstanceList
            // 
            this.cboSqlServerInstanceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboSqlServerInstanceList.FormattingEnabled = true;
            this.cboSqlServerInstanceList.Location = new System.Drawing.Point(203, 12);
            this.cboSqlServerInstanceList.Name = "cboSqlServerInstanceList";
            this.cboSqlServerInstanceList.Size = new System.Drawing.Size(277, 98);
            this.cboSqlServerInstanceList.Sorted = true;
            this.cboSqlServerInstanceList.TabIndex = 21;
            this.cboSqlServerInstanceList.SelectedIndexChanged += new System.EventHandler(this.cboSqlServerInstanceList_SelectedIndexChanged);
            // 
            // lstDatabaseList
            // 
            this.lstDatabaseList.FormattingEnabled = true;
            this.lstDatabaseList.Location = new System.Drawing.Point(203, 116);
            this.lstDatabaseList.Name = "lstDatabaseList";
            this.lstDatabaseList.Size = new System.Drawing.Size(277, 95);
            this.lstDatabaseList.TabIndex = 20;
            // 
            // optRemote
            // 
            this.optRemote.AutoSize = true;
            this.optRemote.Location = new System.Drawing.Point(135, 38);
            this.optRemote.Name = "optRemote";
            this.optRemote.Size = new System.Drawing.Size(62, 17);
            this.optRemote.TabIndex = 19;
            this.optRemote.Text = "Remote";
            this.optRemote.UseVisualStyleBackColor = true;
            this.optRemote.CheckedChanged += new System.EventHandler(this.optRemote_CheckedChanged);
            // 
            // optLocal
            // 
            this.optLocal.AutoSize = true;
            this.optLocal.Location = new System.Drawing.Point(135, 15);
            this.optLocal.Name = "optLocal";
            this.optLocal.Size = new System.Drawing.Size(51, 17);
            this.optLocal.TabIndex = 18;
            this.optLocal.Text = "Local";
            this.optLocal.UseVisualStyleBackColor = true;
            this.optLocal.CheckedChanged += new System.EventHandler(this.optLocal_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Available Databases";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "SQL Server Instances";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.optSQLServer);
            this.panel1.Controls.Add(this.optWindows);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 104);
            this.panel1.TabIndex = 23;
            // 
            // optSQLServer
            // 
            this.optSQLServer.AutoSize = true;
            this.optSQLServer.Location = new System.Drawing.Point(201, 26);
            this.optSQLServer.Name = "optSQLServer";
            this.optSQLServer.Size = new System.Drawing.Size(151, 17);
            this.optSQLServer.TabIndex = 34;
            this.optSQLServer.Text = "SQL Server Authentication";
            this.optSQLServer.UseVisualStyleBackColor = true;
            this.optSQLServer.CheckedChanged += new System.EventHandler(this.optSQLServer_CheckedChanged);
            // 
            // optWindows
            // 
            this.optWindows.AutoSize = true;
            this.optWindows.Checked = true;
            this.optWindows.Location = new System.Drawing.Point(201, 3);
            this.optWindows.Name = "optWindows";
            this.optWindows.Size = new System.Drawing.Size(140, 17);
            this.optWindows.TabIndex = 33;
            this.optWindows.TabStop = true;
            this.optWindows.Text = "Windows Authentication";
            this.optWindows.UseVisualStyleBackColor = true;
            this.optWindows.CheckedChanged += new System.EventHandler(this.optWindows_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(201, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(277, 20);
            this.txtPassword.TabIndex = 32;
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(201, 49);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(277, 20);
            this.txtUserName.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "User Name";
            // 
            // Installation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.cboSqlServerInstanceList);
            this.Controls.Add(this.lstDatabaseList);
            this.Controls.Add(this.optRemote);
            this.Controls.Add(this.optLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Installation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.ComboBox cboSqlServerInstanceList;
        private System.Windows.Forms.ListBox lstDatabaseList;
        private System.Windows.Forms.RadioButton optRemote;
        private System.Windows.Forms.RadioButton optLocal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optSQLServer;
        private System.Windows.Forms.RadioButton optWindows;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

