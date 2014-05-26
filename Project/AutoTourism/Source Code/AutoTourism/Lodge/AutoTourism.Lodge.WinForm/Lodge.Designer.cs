namespace AutoTourism.Lodge.WinForm
{
    partial class Lodge
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
            this.bttnRemoveEmail = new System.Windows.Forms.Button();
            this.bttnRemoveFax = new System.Windows.Forms.Button();
            this.bttnRemoveContact = new System.Windows.Forms.Button();
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtServiceTaxNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLuxTaxNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnRemoveEmail
            // 
            this.bttnRemoveEmail.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRemoveEmail.Location = new System.Drawing.Point(295, 337);
            this.bttnRemoveEmail.Name = "bttnRemoveEmail";
            this.bttnRemoveEmail.Size = new System.Drawing.Size(32, 22);
            this.bttnRemoveEmail.TabIndex = 24;
            this.bttnRemoveEmail.Text = "x";
            this.bttnRemoveEmail.UseVisualStyleBackColor = true;
            this.bttnRemoveEmail.Click += new System.EventHandler(this.bttnRemoveEmail_Click);
            // 
            // bttnRemoveFax
            // 
            this.bttnRemoveFax.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRemoveFax.Location = new System.Drawing.Point(295, 288);
            this.bttnRemoveFax.Name = "bttnRemoveFax";
            this.bttnRemoveFax.Size = new System.Drawing.Size(32, 22);
            this.bttnRemoveFax.TabIndex = 20;
            this.bttnRemoveFax.Text = "x";
            this.bttnRemoveFax.UseVisualStyleBackColor = true;
            this.bttnRemoveFax.Click += new System.EventHandler(this.bttnRemoveFax_Click);
            // 
            // bttnRemoveContact
            // 
            this.bttnRemoveContact.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRemoveContact.Location = new System.Drawing.Point(295, 238);
            this.bttnRemoveContact.Name = "bttnRemoveContact";
            this.bttnRemoveContact.Size = new System.Drawing.Size(32, 22);
            this.bttnRemoveContact.TabIndex = 16;
            this.bttnRemoveContact.Text = "x";
            this.bttnRemoveContact.UseVisualStyleBackColor = true;
            this.bttnRemoveContact.Click += new System.EventHandler(this.bttnRemoveContact_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(132, 241);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(134, 20);
            this.txtMobile.TabIndex = 13;
            // 
            // txtMobilePrefix
            // 
            this.txtMobilePrefix.Enabled = false;
            this.txtMobilePrefix.Location = new System.Drawing.Point(103, 241);
            this.txtMobilePrefix.Name = "txtMobilePrefix";
            this.txtMobilePrefix.Size = new System.Drawing.Size(23, 20);
            this.txtMobilePrefix.TabIndex = 74;
            this.txtMobilePrefix.Text = "+91";
            // 
            // lstEmail
            // 
            this.lstEmail.FormattingEnabled = true;
            this.lstEmail.Location = new System.Drawing.Point(361, 316);
            this.lstEmail.Name = "lstEmail";
            this.lstEmail.Size = new System.Drawing.Size(163, 43);
            this.lstEmail.TabIndex = 23;
            // 
            // bttnAddEmail
            // 
            this.bttnAddEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddEmail.Location = new System.Drawing.Point(295, 314);
            this.bttnAddEmail.Name = "bttnAddEmail";
            this.bttnAddEmail.Size = new System.Drawing.Size(32, 22);
            this.bttnAddEmail.TabIndex = 22;
            this.bttnAddEmail.Text = "  ►";
            this.bttnAddEmail.UseVisualStyleBackColor = true;
            this.bttnAddEmail.Click += new System.EventHandler(this.bttnAddEmail_Click);
            // 
            // bttnAddFax
            // 
            this.bttnAddFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddFax.Location = new System.Drawing.Point(295, 266);
            this.bttnAddFax.Name = "bttnAddFax";
            this.bttnAddFax.Size = new System.Drawing.Size(32, 22);
            this.bttnAddFax.TabIndex = 18;
            this.bttnAddFax.Text = "  ►";
            this.bttnAddFax.UseVisualStyleBackColor = true;
            this.bttnAddFax.Click += new System.EventHandler(this.bttnAddFax_Click);
            // 
            // lslFax
            // 
            this.lslFax.FormattingEnabled = true;
            this.lslFax.Location = new System.Drawing.Point(361, 267);
            this.lslFax.Name = "lslFax";
            this.lslFax.Size = new System.Drawing.Size(163, 43);
            this.lslFax.TabIndex = 19;
            // 
            // bttnAddContact
            // 
            this.bttnAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddContact.Location = new System.Drawing.Point(295, 216);
            this.bttnAddContact.Name = "bttnAddContact";
            this.bttnAddContact.Size = new System.Drawing.Size(32, 22);
            this.bttnAddContact.TabIndex = 14;
            this.bttnAddContact.Text = "  ►";
            this.bttnAddContact.UseVisualStyleBackColor = true;
            this.bttnAddContact.Click += new System.EventHandler(this.bttnAddContact_Click);
            // 
            // txtStd
            // 
            this.txtStd.Location = new System.Drawing.Point(132, 218);
            this.txtStd.Name = "txtStd";
            this.txtStd.Size = new System.Drawing.Size(47, 20);
            this.txtStd.TabIndex = 11;
            // 
            // txtIsd
            // 
            this.txtIsd.Enabled = false;
            this.txtIsd.Location = new System.Drawing.Point(103, 218);
            this.txtIsd.Name = "txtIsd";
            this.txtIsd.Size = new System.Drawing.Size(23, 20);
            this.txtIsd.TabIndex = 67;
            this.txtIsd.Text = "+91";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(361, 218);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(163, 43);
            this.lstContact.TabIndex = 15;
            // 
            // bttnBrowse
            // 
            this.bttnBrowse.Location = new System.Drawing.Point(400, 8);
            this.bttnBrowse.Name = "bttnBrowse";
            this.bttnBrowse.Size = new System.Drawing.Size(54, 22);
            this.bttnBrowse.TabIndex = 2;
            this.bttnBrowse.Text = "Logo";
            this.bttnBrowse.UseVisualStyleBackColor = true;
            this.bttnBrowse.Click += new System.EventHandler(this.bttnBrowse_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(460, 9);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(64, 64);
            this.picLogo.TabIndex = 64;
            this.picLogo.TabStop = false;
            // 
            // cboState
            // 
            this.cboState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(361, 191);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(163, 21);
            this.cboState.TabIndex = 10;
            // 
            // txtConatcName
            // 
            this.txtConatcName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtConatcName.Location = new System.Drawing.Point(103, 365);
            this.txtConatcName.Name = "txtConatcName";
            this.txtConatcName.Size = new System.Drawing.Size(421, 20);
            this.txtConatcName.TabIndex = 25;
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(8, 369);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(75, 13);
            this.lblContactName.TabIndex = 61;
            this.lblContactName.Text = "Contact Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(103, 316);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(163, 20);
            this.txtEmail.TabIndex = 21;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(8, 320);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 57;
            this.lblEmail.Text = "Emails";
            // 
            // txtFaxNumber
            // 
            this.txtFaxNumber.Location = new System.Drawing.Point(103, 267);
            this.txtFaxNumber.Name = "txtFaxNumber";
            this.txtFaxNumber.Size = new System.Drawing.Size(163, 20);
            this.txtFaxNumber.TabIndex = 17;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(8, 271);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(32, 13);
            this.lblFax.TabIndex = 55;
            this.lblFax.Text = "FAXs";
            // 
            // txtLandLine
            // 
            this.txtLandLine.Location = new System.Drawing.Point(185, 218);
            this.txtLandLine.Name = "txtLandLine";
            this.txtLandLine.Size = new System.Drawing.Size(81, 20);
            this.txtLandLine.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Contact Numbers";
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtPin.Location = new System.Drawing.Point(361, 163);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(163, 20);
            this.txtPin.TabIndex = 9;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(275, 166);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(50, 13);
            this.lblPin.TabIndex = 51;
            this.lblPin.Text = "Pin Code";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(272, 194);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 50;
            this.lblState.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtCity.Location = new System.Drawing.Point(361, 133);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(163, 20);
            this.txtCity.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(275, 136);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 48;
            this.lblCity.Text = "City";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtAdds.Location = new System.Drawing.Point(103, 132);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(163, 80);
            this.txtAdds.TabIndex = 7;
            // 
            // lblAdds
            // 
            this.lblAdds.AutoSize = true;
            this.lblAdds.Location = new System.Drawing.Point(7, 136);
            this.lblAdds.Name = "lblAdds";
            this.lblAdds.Size = new System.Drawing.Size(45, 13);
            this.lblAdds.TabIndex = 46;
            this.lblAdds.Text = "Address";
            // 
            // txtTan
            // 
            this.txtTan.Location = new System.Drawing.Point(361, 79);
            this.txtTan.Name = "txtTan";
            this.txtTan.Size = new System.Drawing.Size(163, 20);
            this.txtTan.TabIndex = 4;
            // 
            // lblTan
            // 
            this.lblTan.AutoSize = true;
            this.lblTan.Location = new System.Drawing.Point(275, 82);
            this.lblTan.Name = "lblTan";
            this.lblTan.Size = new System.Drawing.Size(29, 13);
            this.lblTan.TabIndex = 44;
            this.lblTan.Text = "TAN";
            // 
            // txtLiscNo
            // 
            this.txtLiscNo.Location = new System.Drawing.Point(103, 80);
            this.txtLiscNo.Name = "txtLiscNo";
            this.txtLiscNo.Size = new System.Drawing.Size(163, 20);
            this.txtLiscNo.TabIndex = 3;
            // 
            // lblLiscNo
            // 
            this.lblLiscNo.AutoSize = true;
            this.lblLiscNo.Location = new System.Drawing.Point(7, 83);
            this.lblLiscNo.Name = "lblLiscNo";
            this.lblLiscNo.Size = new System.Drawing.Size(90, 13);
            this.lblLiscNo.TabIndex = 42;
            this.lblLiscNo.Text = "Liscence Number";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.txtName.Location = new System.Drawing.Point(103, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(291, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 40;
            this.lblName.Text = "Name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(530, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "O&K";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtServiceTaxNo
            // 
            this.txtServiceTaxNo.Location = new System.Drawing.Point(361, 105);
            this.txtServiceTaxNo.Name = "txtServiceTaxNo";
            this.txtServiceTaxNo.Size = new System.Drawing.Size(163, 20);
            this.txtServiceTaxNo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Service Tax No";
            // 
            // txtLuxTaxNo
            // 
            this.txtLuxTaxNo.Location = new System.Drawing.Point(103, 106);
            this.txtLuxTaxNo.Name = "txtLuxTaxNo";
            this.txtLuxTaxNo.Size = new System.Drawing.Size(163, 20);
            this.txtLuxTaxNo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Luxury Tax No";
            // 
            // Lodge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 394);
            this.Controls.Add(this.txtServiceTaxNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLuxTaxNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.bttnRemoveEmail);
            this.Controls.Add(this.bttnRemoveFax);
            this.Controls.Add(this.bttnRemoveContact);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lodge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lodge Configuration";
            this.Load += new System.EventHandler(this.Lodge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogLogoBrowse;
        private System.Windows.Forms.Button bttnRemoveEmail;
        private System.Windows.Forms.Button bttnRemoveFax;
        private System.Windows.Forms.Button bttnRemoveContact;
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtServiceTaxNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLuxTaxNo;
        private System.Windows.Forms.Label label2;
    }
}

