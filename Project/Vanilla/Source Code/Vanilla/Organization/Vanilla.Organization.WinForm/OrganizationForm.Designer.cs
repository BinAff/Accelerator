namespace Vanilla.Organization.WinForm
{
    partial class OrganizationForm
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
            this.openFileDialogLogoBrowse = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtMobilePrefix = new System.Windows.Forms.TextBox();
            this.lstEmail = new System.Windows.Forms.ListBox();
            this.bttnAddEmail = new System.Windows.Forms.Button();
            this.bttnAddFax = new System.Windows.Forms.Button();
            this.lslFax = new System.Windows.Forms.ListBox();
            this.bttnAddContact = new System.Windows.Forms.Button();
            this.txtStd = new System.Windows.Forms.TextBox();
            this.txtIsd = new System.Windows.Forms.TextBox();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.bttnBrowse = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.txtConatcName = new System.Windows.Forms.TextBox();
            this.lblContactName = new System.Windows.Forms.Label();
            this.txtLogoPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFaxNumber = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtLandLine = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.lblAdds = new System.Windows.Forms.Label();
            this.txtTan = new System.Windows.Forms.TextBox();
            this.lblTan = new System.Windows.Forms.Label();
            this.txtLiscNo = new System.Windows.Forms.TextBox();
            this.lblLiscNo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(281, 424);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 22);
            this.button3.TabIndex = 78;
            this.button3.Text = "x";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.bttnRemoveEmail_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(281, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 22);
            this.button2.TabIndex = 77;
            this.button2.Text = "x";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.bttnRemoveFax_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(281, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 22);
            this.button1.TabIndex = 76;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bttnRemoveContact_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(135, 328);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(134, 20);
            this.txtMobile.TabIndex = 75;
            // 
            // txtMobilePrefix
            // 
            this.txtMobilePrefix.Enabled = false;
            this.txtMobilePrefix.Location = new System.Drawing.Point(106, 328);
            this.txtMobilePrefix.Name = "txtMobilePrefix";
            this.txtMobilePrefix.Size = new System.Drawing.Size(23, 20);
            this.txtMobilePrefix.TabIndex = 74;
            this.txtMobilePrefix.Text = "+91";
            // 
            // lstEmail
            // 
            this.lstEmail.FormattingEnabled = true;
            this.lstEmail.Location = new System.Drawing.Point(319, 403);
            this.lstEmail.Name = "lstEmail";
            this.lstEmail.Size = new System.Drawing.Size(154, 43);
            this.lstEmail.TabIndex = 73;
            // 
            // bttnAddEmail
            // 
            this.bttnAddEmail.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddEmail.Location = new System.Drawing.Point(281, 401);
            this.bttnAddEmail.Name = "bttnAddEmail";
            this.bttnAddEmail.Size = new System.Drawing.Size(32, 22);
            this.bttnAddEmail.TabIndex = 72;
            this.bttnAddEmail.Text = "  ►";
            this.bttnAddEmail.UseVisualStyleBackColor = true;
            this.bttnAddEmail.Click += new System.EventHandler(this.bttnAddEmail_Click);
            // 
            // bttnAddFax
            // 
            this.bttnAddFax.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddFax.Location = new System.Drawing.Point(281, 353);
            this.bttnAddFax.Name = "bttnAddFax";
            this.bttnAddFax.Size = new System.Drawing.Size(32, 22);
            this.bttnAddFax.TabIndex = 71;
            this.bttnAddFax.Text = "  ►";
            this.bttnAddFax.UseVisualStyleBackColor = true;
            this.bttnAddFax.Click += new System.EventHandler(this.bttnAddFax_Click);
            // 
            // lslFax
            // 
            this.lslFax.FormattingEnabled = true;
            this.lslFax.Location = new System.Drawing.Point(319, 354);
            this.lslFax.Name = "lslFax";
            this.lslFax.Size = new System.Drawing.Size(154, 43);
            this.lslFax.TabIndex = 70;
            // 
            // bttnAddContact
            // 
            this.bttnAddContact.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddContact.Location = new System.Drawing.Point(281, 303);
            this.bttnAddContact.Name = "bttnAddContact";
            this.bttnAddContact.Size = new System.Drawing.Size(32, 22);
            this.bttnAddContact.TabIndex = 69;
            this.bttnAddContact.Text = "  ►";
            this.bttnAddContact.UseVisualStyleBackColor = true;
            this.bttnAddContact.Click += new System.EventHandler(this.bttnAddContact_Click);
            // 
            // txtStd
            // 
            this.txtStd.Location = new System.Drawing.Point(135, 305);
            this.txtStd.Name = "txtStd";
            this.txtStd.Size = new System.Drawing.Size(47, 20);
            this.txtStd.TabIndex = 68;
            // 
            // txtIsd
            // 
            this.txtIsd.Enabled = false;
            this.txtIsd.Location = new System.Drawing.Point(106, 305);
            this.txtIsd.Name = "txtIsd";
            this.txtIsd.Size = new System.Drawing.Size(23, 20);
            this.txtIsd.TabIndex = 67;
            this.txtIsd.Text = "+91";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(319, 305);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(154, 43);
            this.lstContact.TabIndex = 66;
            // 
            // bttnBrowse
            // 
            this.bttnBrowse.Location = new System.Drawing.Point(106, 67);
            this.bttnBrowse.Name = "bttnBrowse";
            this.bttnBrowse.Size = new System.Drawing.Size(93, 22);
            this.bttnBrowse.TabIndex = 65;
            this.bttnBrowse.Text = "Browse";
            this.bttnBrowse.UseVisualStyleBackColor = true;
            this.bttnBrowse.Click += new System.EventHandler(this.bttnBrowse_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(205, 68);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(64, 64);
            this.picLogo.TabIndex = 64;
            this.picLogo.TabStop = false;
            // 
            // cboState
            // 
            this.cboState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(313, 251);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(160, 21);
            this.cboState.TabIndex = 63;
            this.cboState.Text = "West Bengal";
            // 
            // txtConatcName
            // 
            this.txtConatcName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtConatcName.Location = new System.Drawing.Point(106, 452);
            this.txtConatcName.Name = "txtConatcName";
            this.txtConatcName.Size = new System.Drawing.Size(367, 20);
            this.txtConatcName.TabIndex = 62;
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(11, 456);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(75, 13);
            this.lblContactName.TabIndex = 61;
            this.lblContactName.Text = "Contact Name";
            // 
            // txtLogoPath
            // 
            this.txtLogoPath.Enabled = false;
            this.txtLogoPath.Location = new System.Drawing.Point(275, 67);
            this.txtLogoPath.Multiline = true;
            this.txtLogoPath.Name = "txtLogoPath";
            this.txtLogoPath.Size = new System.Drawing.Size(198, 65);
            this.txtLogoPath.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Logo";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(106, 403);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(163, 20);
            this.txtEmail.TabIndex = 58;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(11, 407);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 57;
            this.lblEmail.Text = "Emails";
            // 
            // txtFaxNumber
            // 
            this.txtFaxNumber.Location = new System.Drawing.Point(106, 354);
            this.txtFaxNumber.Name = "txtFaxNumber";
            this.txtFaxNumber.Size = new System.Drawing.Size(163, 20);
            this.txtFaxNumber.TabIndex = 56;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(11, 358);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(32, 13);
            this.lblFax.TabIndex = 55;
            this.lblFax.Text = "FAXs";
            // 
            // txtLandLine
            // 
            this.txtLandLine.Location = new System.Drawing.Point(188, 305);
            this.txtLandLine.Name = "txtLandLine";
            this.txtLandLine.Size = new System.Drawing.Size(81, 20);
            this.txtLandLine.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Contact Numbers";
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtPin.Location = new System.Drawing.Point(106, 278);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(163, 20);
            this.txtPin.TabIndex = 52;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(10, 282);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(50, 13);
            this.lblPin.TabIndex = 51;
            this.lblPin.Text = "Pin Code";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(275, 255);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 50;
            this.lblState.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtCity.Location = new System.Drawing.Point(106, 251);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(163, 20);
            this.txtCity.TabIndex = 49;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(10, 255);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 48;
            this.lblCity.Text = "City";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtAdds.Location = new System.Drawing.Point(106, 165);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(367, 80);
            this.txtAdds.TabIndex = 47;
            // 
            // lblAdds
            // 
            this.lblAdds.AutoSize = true;
            this.lblAdds.Location = new System.Drawing.Point(10, 169);
            this.lblAdds.Name = "lblAdds";
            this.lblAdds.Size = new System.Drawing.Size(45, 13);
            this.lblAdds.TabIndex = 46;
            this.lblAdds.Text = "Address";
            // 
            // txtTan
            // 
            this.txtTan.Location = new System.Drawing.Point(352, 138);
            this.txtTan.Name = "txtTan";
            this.txtTan.Size = new System.Drawing.Size(121, 20);
            this.txtTan.TabIndex = 45;
            // 
            // lblTan
            // 
            this.lblTan.AutoSize = true;
            this.lblTan.Location = new System.Drawing.Point(272, 141);
            this.lblTan.Name = "lblTan";
            this.lblTan.Size = new System.Drawing.Size(29, 13);
            this.lblTan.TabIndex = 44;
            this.lblTan.Text = "TAN";
            // 
            // txtLiscNo
            // 
            this.txtLiscNo.Location = new System.Drawing.Point(106, 139);
            this.txtLiscNo.Name = "txtLiscNo";
            this.txtLiscNo.Size = new System.Drawing.Size(163, 20);
            this.txtLiscNo.TabIndex = 43;
            // 
            // lblLiscNo
            // 
            this.lblLiscNo.AutoSize = true;
            this.lblLiscNo.Location = new System.Drawing.Point(10, 142);
            this.lblLiscNo.Name = "lblLiscNo";
            this.lblLiscNo.Size = new System.Drawing.Size(90, 13);
            this.lblLiscNo.TabIndex = 42;
            this.lblLiscNo.Text = "Liscence Number";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtName.Location = new System.Drawing.Point(106, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(367, 20);
            this.txtName.TabIndex = 41;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 40;
            this.lblName.Text = "Name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(491, 169);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 79;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OrganizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 485);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtMobilePrefix);
            this.Controls.Add(this.lstEmail);
            this.Controls.Add(this.bttnAddEmail);
            this.Controls.Add(this.bttnAddFax);
            this.Controls.Add(this.lslFax);
            this.Controls.Add(this.bttnAddContact);
            this.Controls.Add(this.txtStd);
            this.Controls.Add(this.txtIsd);
            this.Controls.Add(this.lstContact);
            this.Controls.Add(this.bttnBrowse);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.txtConatcName);
            this.Controls.Add(this.lblContactName);
            this.Controls.Add(this.txtLogoPath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFaxNumber);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtLandLine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtAdds);
            this.Controls.Add(this.lblAdds);
            this.Controls.Add(this.txtTan);
            this.Controls.Add(this.lblTan);
            this.Controls.Add(this.txtLiscNo);
            this.Controls.Add(this.lblLiscNo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "OrganizationForm";
            this.Text = "Organization Form";
            this.Load += new System.EventHandler(this.OrganizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogLogoBrowse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtMobilePrefix;
        private System.Windows.Forms.ListBox lstEmail;
        private System.Windows.Forms.Button bttnAddEmail;
        private System.Windows.Forms.Button bttnAddFax;
        private System.Windows.Forms.ListBox lslFax;
        private System.Windows.Forms.Button bttnAddContact;
        private System.Windows.Forms.TextBox txtStd;
        private System.Windows.Forms.TextBox txtIsd;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Button bttnBrowse;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.TextBox txtConatcName;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.TextBox txtLogoPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtFaxNumber;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtLandLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.Label lblAdds;
        private System.Windows.Forms.TextBox txtTan;
        private System.Windows.Forms.Label lblTan;
        private System.Windows.Forms.TextBox txtLiscNo;
        private System.Windows.Forms.Label lblLiscNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button button4;
    }
}

