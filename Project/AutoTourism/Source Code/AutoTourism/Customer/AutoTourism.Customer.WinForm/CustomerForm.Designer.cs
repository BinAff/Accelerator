namespace AutoTourism.Customer.WinForm
{
    partial class CustomerForm
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
            this.bttnRemove = new System.Windows.Forms.Button();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtMobilePrefix = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.txtStd = new System.Windows.Forms.TextBox();
            this.txtIsd = new System.Windows.Forms.TextBox();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.txtLandLine = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProofType = new System.Windows.Forms.ComboBox();
            this.txtIdentityProofName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtArtifactPath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnRemove
            // 
            this.bttnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRemove.Location = new System.Drawing.Point(294, 135);
            this.bttnRemove.Name = "bttnRemove";
            this.bttnRemove.Size = new System.Drawing.Size(32, 22);
            this.bttnRemove.TabIndex = 13;
            this.bttnRemove.Text = "X";
            this.bttnRemove.UseVisualStyleBackColor = true;
            this.bttnRemove.Click += new System.EventHandler(this.bttnRemove_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(143, 137);
            this.txtMobile.MaxLength = 12;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(131, 20);
            this.txtMobile.TabIndex = 10;
            // 
            // txtMobilePrefix
            // 
            this.txtMobilePrefix.Enabled = false;
            this.txtMobilePrefix.Location = new System.Drawing.Point(106, 137);
            this.txtMobilePrefix.Name = "txtMobilePrefix";
            this.txtMobilePrefix.Size = new System.Drawing.Size(31, 20);
            this.txtMobilePrefix.TabIndex = 999;
            this.txtMobilePrefix.TabStop = false;
            this.txtMobilePrefix.Text = "+91";
            // 
            // btnAddContact
            // 
            this.btnAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact.Location = new System.Drawing.Point(294, 114);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(32, 22);
            this.btnAddContact.TabIndex = 11;
            this.btnAddContact.Text = " ►";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // txtStd
            // 
            this.txtStd.Location = new System.Drawing.Point(143, 114);
            this.txtStd.MaxLength = 5;
            this.txtStd.Name = "txtStd";
            this.txtStd.Size = new System.Drawing.Size(39, 20);
            this.txtStd.TabIndex = 8;
            // 
            // txtIsd
            // 
            this.txtIsd.Enabled = false;
            this.txtIsd.Location = new System.Drawing.Point(106, 114);
            this.txtIsd.Name = "txtIsd";
            this.txtIsd.Size = new System.Drawing.Size(31, 20);
            this.txtIsd.TabIndex = 999;
            this.txtIsd.TabStop = false;
            this.txtIsd.Text = "+91";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(344, 114);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(168, 43);
            this.lstContact.TabIndex = 12;
            // 
            // txtLandLine
            // 
            this.txtLandLine.Location = new System.Drawing.Point(188, 114);
            this.txtLandLine.MaxLength = 10;
            this.txtLandLine.Name = "txtLandLine";
            this.txtLandLine.Size = new System.Drawing.Size(86, 20);
            this.txtLandLine.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Contact Numbers";
            // 
            // cboProofType
            // 
            this.cboProofType.FormattingEnabled = true;
            this.cboProofType.Location = new System.Drawing.Point(106, 188);
            this.cboProofType.Name = "cboProofType";
            this.cboProofType.Size = new System.Drawing.Size(168, 21);
            this.cboProofType.TabIndex = 15;
            // 
            // txtIdentityProofName
            // 
            this.txtIdentityProofName.Location = new System.Drawing.Point(294, 188);
            this.txtIdentityProofName.MaxLength = 20;
            this.txtIdentityProofName.Name = "txtIdentityProofName";
            this.txtIdentityProofName.Size = new System.Drawing.Size(218, 20);
            this.txtIdentityProofName.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Identity Proof";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(106, 163);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "EMail";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(344, 91);
            this.txtPin.MaxLength = 8;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(168, 20);
            this.txtPin.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Pin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCity.Location = new System.Drawing.Point(344, 65);
            this.txtCity.MaxLength = 20;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(168, 20);
            this.txtCity.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "City";
            // 
            // cboState
            // 
            this.cboState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(344, 38);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(168, 21);
            this.cboState.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Address";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtAdds.Location = new System.Drawing.Point(106, 38);
            this.txtAdds.MaxLength = 255;
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(168, 73);
            this.txtAdds.TabIndex = 4;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(391, 12);
            this.txtLName.MaxLength = 20;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(121, 20);
            this.txtLName.TabIndex = 3;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(272, 12);
            this.txtMName.MaxLength = 20;
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(113, 20);
            this.txtMName.TabIndex = 2;
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFName.Location = new System.Drawing.Point(106, 12);
            this.txtFName.MaxLength = 20;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(160, 20);
            this.txtFName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 86;
            this.lblName.Text = "Name";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(528, 41);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1000;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(528, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1001;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1004;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtArtifactPath
            // 
            this.txtArtifactPath.Location = new System.Drawing.Point(106, 215);
            this.txtArtifactPath.Name = "txtArtifactPath";
            this.txtArtifactPath.Size = new System.Drawing.Size(406, 20);
            this.txtArtifactPath.TabIndex = 1003;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 218);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 1002;
            this.lblFilePath.Text = "File Path:";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 247);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtArtifactPath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAdds);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.bttnRemove);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtMobilePrefix);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.txtStd);
            this.Controls.Add(this.txtIsd);
            this.Controls.Add(this.lstContact);
            this.Controls.Add(this.txtLandLine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboProofType);
            this.Controls.Add(this.txtIdentityProofName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.label1);
            this.Name = "CustomerForm";
            this.Text = "Customer Registration Form";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnRemove;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtMobilePrefix;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.TextBox txtStd;
        private System.Windows.Forms.TextBox txtIsd;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.TextBox txtLandLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProofType;
        private System.Windows.Forms.TextBox txtIdentityProofName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtArtifactPath;
        private System.Windows.Forms.Label lblFilePath;
    }
}