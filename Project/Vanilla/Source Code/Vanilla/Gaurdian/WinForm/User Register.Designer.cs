namespace Vanilla.Guardian.WinForm
{
    partial class UserRegister
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
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.tbcUser = new System.Windows.Forms.TabControl();
            this.tapProfile = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
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
            this.tbcUser.SuspendLayout();
            this.tapProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboUser
            // 
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(15, 14);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(154, 208);
            this.cboUser.Sorted = true;
            this.cboUser.TabIndex = 53;
            this.cboUser.Click += new System.EventHandler(this.cboUser_Click);
            // 
            // tbcUser
            // 
            this.tbcUser.Controls.Add(this.tapProfile);
            this.tbcUser.Controls.Add(this.tapLogin);
            this.tbcUser.Location = new System.Drawing.Point(185, 14);
            this.tbcUser.Name = "tbcUser";
            this.tbcUser.SelectedIndex = 0;
            this.tbcUser.Size = new System.Drawing.Size(453, 208);
            this.tbcUser.TabIndex = 52;
            // 
            // tapProfile
            // 
            this.tapProfile.Controls.Add(this.btnRefresh);
            this.tapProfile.Controls.Add(this.btnDelete);
            this.tapProfile.Controls.Add(this.btnAdd);
            this.tapProfile.Controls.Add(this.btnChange);
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
            this.tapProfile.Size = new System.Drawing.Size(445, 182);
            this.tapProfile.TabIndex = 0;
            this.tapProfile.Text = "Profile";
            this.tapProfile.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(340, 99);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 25);
            this.btnRefresh.TabIndex = 126;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(340, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 25);
            this.btnDelete.TabIndex = 125;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(340, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 25);
            this.btnAdd.TabIndex = 124;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(340, 37);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(94, 25);
            this.btnChange.TabIndex = 123;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(340, 131);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(94, 25);
            this.btnResetPassword.TabIndex = 48;
            this.btnResetPassword.Text = "Reset Password";
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
            this.tapLogin.Size = new System.Drawing.Size(445, 182);
            this.tapLogin.TabIndex = 1;
            this.tapLogin.Text = "Login History";
            this.tapLogin.UseVisualStyleBackColor = true;
            // 
            // UserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 233);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.tbcUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Register";
            this.Load += new System.EventHandler(this.UserRegister_Load);
            this.tbcUser.ResumeLayout(false);
            this.tapProfile.ResumeLayout(false);
            this.tapProfile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.TabControl tbcUser;
        private System.Windows.Forms.TabPage tapProfile;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkLstRole;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabPage tapLogin;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
    }
}