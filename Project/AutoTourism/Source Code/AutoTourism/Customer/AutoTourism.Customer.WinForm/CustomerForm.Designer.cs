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
            this.bttnRemove = new System.Windows.Forms.Button();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtMobilePrefix = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.txtStd = new System.Windows.Forms.TextBox();
            this.txtIsd = new System.Windows.Forms.TextBox();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.txtLandLine = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIdentityProofType = new System.Windows.Forms.ComboBox();
            this.txtIdentityProofName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStateList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNationList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnRemove
            // 
            this.bttnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRemove.Location = new System.Drawing.Point(240, 209);
            this.bttnRemove.Name = "bttnRemove";
            this.bttnRemove.Size = new System.Drawing.Size(32, 22);
            this.bttnRemove.TabIndex = 14;
            this.bttnRemove.Text = "X";
            this.bttnRemove.UseVisualStyleBackColor = true;
            this.bttnRemove.Click += new System.EventHandler(this.bttnRemove_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(141, 210);
            this.txtMobile.MaxLength = 12;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(92, 20);
            this.txtMobile.TabIndex = 11;
            // 
            // txtMobilePrefix
            // 
            this.txtMobilePrefix.Enabled = false;
            this.txtMobilePrefix.Location = new System.Drawing.Point(104, 210);
            this.txtMobilePrefix.Name = "txtMobilePrefix";
            this.txtMobilePrefix.Size = new System.Drawing.Size(31, 20);
            this.txtMobilePrefix.TabIndex = 999;
            this.txtMobilePrefix.TabStop = false;
            this.txtMobilePrefix.Text = "+91";
            // 
            // btnAddContact
            // 
            this.btnAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact.Location = new System.Drawing.Point(240, 186);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(32, 22);
            this.btnAddContact.TabIndex = 12;
            this.btnAddContact.Text = " ►";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // txtStd
            // 
            this.txtStd.Location = new System.Drawing.Point(141, 187);
            this.txtStd.MaxLength = 5;
            this.txtStd.Name = "txtStd";
            this.txtStd.Size = new System.Drawing.Size(31, 20);
            this.txtStd.TabIndex = 9;
            // 
            // txtIsd
            // 
            this.txtIsd.Enabled = false;
            this.txtIsd.Location = new System.Drawing.Point(104, 187);
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
            this.lstContact.Location = new System.Drawing.Point(277, 187);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(169, 43);
            this.lstContact.TabIndex = 13;
            // 
            // txtLandLine
            // 
            this.txtLandLine.Location = new System.Drawing.Point(178, 187);
            this.txtLandLine.MaxLength = 10;
            this.txtLandLine.Name = "txtLandLine";
            this.txtLandLine.Size = new System.Drawing.Size(55, 20);
            this.txtLandLine.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Contact Numbers";
            // 
            // cboIdentityProofType
            // 
            this.cboIdentityProofType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdentityProofType.FormattingEnabled = true;
            this.cboIdentityProofType.Location = new System.Drawing.Point(104, 263);
            this.cboIdentityProofType.Name = "cboIdentityProofType";
            this.cboIdentityProofType.Size = new System.Drawing.Size(168, 21);
            this.cboIdentityProofType.Sorted = true;
            this.cboIdentityProofType.TabIndex = 16;
            // 
            // txtIdentityProofName
            // 
            this.txtIdentityProofName.Location = new System.Drawing.Point(278, 263);
            this.txtIdentityProofName.MaxLength = 20;
            this.txtIdentityProofName.Name = "txtIdentityProofName";
            this.txtIdentityProofName.Size = new System.Drawing.Size(168, 20);
            this.txtIdentityProofName.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Identity Proof";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(104, 237);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "EMail";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(278, 159);
            this.txtPin.MaxLength = 8;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(168, 20);
            this.txtPin.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Pin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCity.Location = new System.Drawing.Point(278, 133);
            this.txtCity.MaxLength = 20;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(168, 20);
            this.txtCity.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "City";
            // 
            // cboState
            // 
            this.cboStateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboStateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStateList.FormattingEnabled = true;
            this.cboStateList.Location = new System.Drawing.Point(278, 106);
            this.cboStateList.Name = "cboState";
            this.cboStateList.Size = new System.Drawing.Size(168, 21);
            this.cboStateList.Sorted = true;
            this.cboStateList.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Permanent Address";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtAdds.Location = new System.Drawing.Point(11, 82);
            this.txtAdds.MaxLength = 255;
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(212, 97);
            this.txtAdds.TabIndex = 4;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(306, 33);
            this.txtLName.MaxLength = 20;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(140, 20);
            this.txtLName.TabIndex = 3;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(195, 33);
            this.txtMName.MaxLength = 20;
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(105, 20);
            this.txtMName.TabIndex = 2;
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFName.Location = new System.Drawing.Point(52, 33);
            this.txtFName.MaxLength = 20;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(137, 20);
            this.txtFName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 86;
            this.lblName.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1002;
            this.label6.Text = "Country";
            // 
            // cboNationList
            // 
            this.cboNationList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboNationList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNationList.FormattingEnabled = true;
            this.cboNationList.Location = new System.Drawing.Point(277, 79);
            this.cboNationList.Name = "cboNationList";
            this.cboNationList.Size = new System.Drawing.Size(168, 21);
            this.cboNationList.Sorted = true;
            this.cboNationList.TabIndex = 5;
            this.cboNationList.SelectedIndexChanged += new System.EventHandler(this.cboNationList_SelectedIndexChanged);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 291);
            this.Controls.Add(this.cboNationList);
            this.Controls.Add(this.label6);
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
            this.Controls.Add(this.cboIdentityProofType);
            this.Controls.Add(this.txtIdentityProofName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStateList);
            this.Controls.Add(this.label1);
            this.Name = "CustomerForm";
            this.ShowInTaskbar = false;
            this.Text = "Customer Registration Form";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboStateList, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCity, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtPin, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtIdentityProofName, 0);
            this.Controls.SetChildIndex(this.cboIdentityProofType, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtLandLine, 0);
            this.Controls.SetChildIndex(this.lstContact, 0);
            this.Controls.SetChildIndex(this.txtIsd, 0);
            this.Controls.SetChildIndex(this.txtStd, 0);
            this.Controls.SetChildIndex(this.btnAddContact, 0);
            this.Controls.SetChildIndex(this.txtMobilePrefix, 0);
            this.Controls.SetChildIndex(this.txtMobile, 0);
            this.Controls.SetChildIndex(this.bttnRemove, 0);
            this.Controls.SetChildIndex(this.txtLName, 0);
            this.Controls.SetChildIndex(this.txtMName, 0);
            this.Controls.SetChildIndex(this.txtFName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtAdds, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboNationList, 0);
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
        private System.Windows.Forms.ComboBox cboIdentityProofType;
        private System.Windows.Forms.TextBox txtIdentityProofName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cboNationList;
        private System.Windows.Forms.Label label6;
    }
}