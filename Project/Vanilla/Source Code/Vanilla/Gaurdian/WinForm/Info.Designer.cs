namespace Vanilla.Guardian.WinForm
{
    partial class Info
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
            this.tbcUser = new System.Windows.Forms.TabControl();
            this.tapProfile = new System.Windows.Forms.TabPage();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLstRole = new System.Windows.Forms.CheckedListBox();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tapLogin = new System.Windows.Forms.TabPage();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.tbcUser.SuspendLayout();
            this.tapProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcUser
            // 
            this.tbcUser.Controls.Add(this.tapProfile);
            this.tbcUser.Controls.Add(this.tapLogin);
            this.tbcUser.Location = new System.Drawing.Point(182, 14);
            this.tbcUser.Name = "tbcUser";
            this.tbcUser.SelectedIndex = 0;
            this.tbcUser.Size = new System.Drawing.Size(455, 260);
            this.tbcUser.TabIndex = 50;
            // 
            // tapProfile
            // 
            this.tapProfile.Controls.Add(this.btnOk);
            this.tapProfile.Controls.Add(this.btnResetPassword);
            this.tapProfile.Controls.Add(this.label1);
            this.tapProfile.Controls.Add(this.chkLstRole);
            this.tapProfile.Controls.Add(this.txtDateOfBirth);
            this.tapProfile.Controls.Add(this.lblDOB);
            this.tapProfile.Controls.Add(this.lstContact);
            this.tapProfile.Controls.Add(this.label5);
            this.tapProfile.Controls.Add(this.txtName);
            this.tapProfile.Controls.Add(this.lblName);
            this.tapProfile.Location = new System.Drawing.Point(4, 22);
            this.tapProfile.Name = "tapProfile";
            this.tapProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tapProfile.Size = new System.Drawing.Size(447, 234);
            this.tapProfile.TabIndex = 0;
            this.tapProfile.Text = "Profile";
            this.tapProfile.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(165, 188);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 123;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(246, 188);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(75, 25);
            this.btnResetPassword.TabIndex = 48;
            this.btnResetPassword.Text = "Reset";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 122;
            this.label1.Text = "Role";
            // 
            // chkLstRole
            // 
            this.chkLstRole.FormattingEnabled = true;
            this.chkLstRole.Location = new System.Drawing.Point(107, 104);
            this.chkLstRole.Name = "chkLstRole";
            this.chkLstRole.Size = new System.Drawing.Size(126, 64);
            this.chkLstRole.TabIndex = 121;
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.Enabled = false;
            this.txtDateOfBirth.Location = new System.Drawing.Point(106, 32);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.Size = new System.Drawing.Size(128, 20);
            this.txtDateOfBirth.TabIndex = 120;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(12, 35);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(66, 13);
            this.lblDOB.TabIndex = 119;
            this.lblDOB.Text = "Date of Birth";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.SystemColors.Window;
            this.lstContact.Enabled = false;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(106, 58);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(128, 43);
            this.lstContact.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Contact Numbers";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(106, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 20);
            this.txtName.TabIndex = 52;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 51;
            this.lblName.Text = "Name";
            // 
            // tapLogin
            // 
            this.tapLogin.Location = new System.Drawing.Point(4, 22);
            this.tapLogin.Name = "tapLogin";
            this.tapLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tapLogin.Size = new System.Drawing.Size(447, 234);
            this.tapLogin.TabIndex = 1;
            this.tapLogin.Text = "Login History";
            this.tapLogin.UseVisualStyleBackColor = true;
            // 
            // cboUser
            // 
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(12, 14);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(154, 260);
            this.cboUser.Sorted = true;
            this.cboUser.TabIndex = 51;
            this.cboUser.Click += new System.EventHandler(this.cboUser_Click);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 286);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.tbcUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.Load += new System.EventHandler(this.Info_Load);
            this.tbcUser.ResumeLayout(false);
            this.tapProfile.ResumeLayout(false);
            this.tapProfile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcUser;
        private System.Windows.Forms.TabPage tapProfile;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TabPage tapLogin;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkLstRole;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cboUser;
    }
}