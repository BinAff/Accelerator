namespace Vanilla.Guardian.WinForm
{
    partial class MyAccount
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.cboSecQ = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.Security = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStd = new System.Windows.Forms.TextBox();
            this.bttnRemove = new System.Windows.Forms.Button();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtMobilePrefix = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.txtIsd = new System.Windows.Forms.TextBox();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.txtLandLine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.cboInitial = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.Security.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(440, 244);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 100;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboSecQ
            // 
            this.cboSecQ.BackColor = System.Drawing.SystemColors.Window;
            this.cboSecQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSecQ.FormattingEnabled = true;
            this.cboSecQ.Items.AddRange(new object[] {
            "Mr.",
            "Mrs.",
            "Ms."});
            this.cboSecQ.Location = new System.Drawing.Point(106, 51);
            this.cboSecQ.Name = "cboSecQ";
            this.cboSecQ.Size = new System.Drawing.Size(376, 21);
            this.cboSecQ.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "Answer";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(106, 84);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(376, 20);
            this.txtAnswer.TabIndex = 17;
            // 
            // Security
            // 
            this.Security.Controls.Add(this.txtPassword);
            this.Security.Controls.Add(this.label2);
            this.Security.Controls.Add(this.txtRePassword);
            this.Security.Controls.Add(this.label1);
            this.Security.Controls.Add(this.label4);
            this.Security.Controls.Add(this.cboSecQ);
            this.Security.Controls.Add(this.label5);
            this.Security.Controls.Add(this.txtAnswer);
            this.Security.Location = new System.Drawing.Point(17, 113);
            this.Security.Name = "Security";
            this.Security.Size = new System.Drawing.Size(498, 116);
            this.Security.TabIndex = 178;
            this.Security.TabStop = false;
            this.Security.Text = "Security";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtPassword.Location = new System.Drawing.Point(106, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(160, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Password";
            // 
            // txtRePassword
            // 
            this.txtRePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtRePassword.Location = new System.Drawing.Point(321, 21);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '*';
            this.txtRePassword.Size = new System.Drawing.Size(160, 20);
            this.txtRePassword.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Retype...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Security Question";
            // 
            // txtStd
            // 
            this.txtStd.Location = new System.Drawing.Point(138, 65);
            this.txtStd.Name = "txtStd";
            this.txtStd.Size = new System.Drawing.Size(47, 20);
            this.txtStd.TabIndex = 7;
            // 
            // bttnRemove
            // 
            this.bttnRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRemove.Location = new System.Drawing.Point(297, 86);
            this.bttnRemove.Name = "bttnRemove";
            this.bttnRemove.Size = new System.Drawing.Size(32, 22);
            this.bttnRemove.TabIndex = 13;
            this.bttnRemove.Text = "◄";
            this.bttnRemove.UseVisualStyleBackColor = true;
            this.bttnRemove.Click += new System.EventHandler(this.bttnRemove_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(138, 88);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(134, 20);
            this.txtMobile.TabIndex = 10;
            // 
            // txtMobilePrefix
            // 
            this.txtMobilePrefix.Enabled = false;
            this.txtMobilePrefix.Location = new System.Drawing.Point(109, 88);
            this.txtMobilePrefix.Name = "txtMobilePrefix";
            this.txtMobilePrefix.Size = new System.Drawing.Size(23, 20);
            this.txtMobilePrefix.TabIndex = 9;
            this.txtMobilePrefix.TabStop = false;
            this.txtMobilePrefix.Text = "+91";
            // 
            // btnAddContact
            // 
            this.btnAddContact.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact.Location = new System.Drawing.Point(297, 65);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(32, 22);
            this.btnAddContact.TabIndex = 11;
            this.btnAddContact.Text = "►";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // txtIsd
            // 
            this.txtIsd.Enabled = false;
            this.txtIsd.Location = new System.Drawing.Point(109, 65);
            this.txtIsd.Name = "txtIsd";
            this.txtIsd.Size = new System.Drawing.Size(23, 20);
            this.txtIsd.TabIndex = 6;
            this.txtIsd.TabStop = false;
            this.txtIsd.Text = "+91";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(347, 65);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(168, 43);
            this.lstContact.TabIndex = 12;
            // 
            // txtLandLine
            // 
            this.txtLandLine.Location = new System.Drawing.Point(191, 65);
            this.txtLandLine.Name = "txtLandLine";
            this.txtLandLine.Size = new System.Drawing.Size(81, 20);
            this.txtLandLine.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 169;
            this.label6.Text = "Contact Numbers";
            // 
            // dtpDob
            // 
            this.dtpDob.Location = new System.Drawing.Point(109, 39);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(163, 20);
            this.dtpDob.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 167;
            this.label3.Text = "Date of Birth";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(394, 13);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(121, 20);
            this.txtLName.TabIndex = 4;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(275, 13);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(113, 20);
            this.txtMName.TabIndex = 3;
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFName.Location = new System.Drawing.Point(163, 13);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(106, 20);
            this.txtFName.TabIndex = 2;
            // 
            // cboInitial
            // 
            this.cboInitial.BackColor = System.Drawing.SystemColors.Window;
            this.cboInitial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInitial.FormattingEnabled = true;
            this.cboInitial.Items.AddRange(new object[] {
            "Mr.",
            "Mrs.",
            "Ms."});
            this.cboInitial.Location = new System.Drawing.Point(109, 13);
            this.cboInitial.Name = "cboInitial";
            this.cboInitial.Size = new System.Drawing.Size(48, 21);
            this.cboInitial.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(14, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 163;
            this.lblName.Text = "Name";
            // 
            // MyAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 281);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.Security);
            this.Controls.Add(this.txtStd);
            this.Controls.Add(this.bttnRemove);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtMobilePrefix);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.txtIsd);
            this.Controls.Add(this.lstContact);
            this.Controls.Add(this.txtLandLine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.cboInitial);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Account";
            this.Load += new System.EventHandler(this.MyAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.Security.ResumeLayout(false);
            this.Security.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox Security;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSecQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.TextBox txtStd;
        private System.Windows.Forms.Button bttnRemove;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtMobilePrefix;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.TextBox txtIsd;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.TextBox txtLandLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.ComboBox cboInitial;
        private System.Windows.Forms.Label lblName;
    }
}