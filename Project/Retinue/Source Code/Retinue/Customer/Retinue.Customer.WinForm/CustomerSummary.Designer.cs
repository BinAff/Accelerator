namespace Retinue.Customer.WinForm
{
    partial class CustomerSummary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.tpnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tpnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 84;
            this.label8.Text = "EMail";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 95);
            this.label7.TabIndex = 82;
            this.label7.Text = "Address";
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.SystemColors.Control;
            this.lstContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(197, 27);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(357, 43);
            this.lstContact.TabIndex = 999;
            this.lstContact.TabStop = false;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 49);
            this.label5.TabIndex = 80;
            this.label5.Text = "Contact Numbers";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(197, 3);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(357, 20);
            this.txtName.TabIndex = 999;
            this.txtName.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(161, 24);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Name";
            // 
            // txtAdds
            // 
            this.txtAdds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAdds.Location = new System.Drawing.Point(197, 76);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.ReadOnly = true;
            this.txtAdds.Size = new System.Drawing.Size(357, 89);
            this.txtAdds.TabIndex = 999;
            this.txtAdds.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(197, 171);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(357, 20);
            this.txtEmail.TabIndex = 999;
            this.txtEmail.TabStop = false;
            // 
            // tpnlContainer
            // 
            this.tpnlContainer.ColumnCount = 3;
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tpnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tpnlContainer.Controls.Add(this.txtEmail, 2, 3);
            this.tpnlContainer.Controls.Add(this.lblName, 0, 0);
            this.tpnlContainer.Controls.Add(this.label8, 0, 3);
            this.tpnlContainer.Controls.Add(this.txtName, 2, 0);
            this.tpnlContainer.Controls.Add(this.txtAdds, 2, 2);
            this.tpnlContainer.Controls.Add(this.lstContact, 2, 1);
            this.tpnlContainer.Controls.Add(this.label7, 0, 2);
            this.tpnlContainer.Controls.Add(this.label5, 0, 1);
            this.tpnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlContainer.Location = new System.Drawing.Point(0, 0);
            this.tpnlContainer.Name = "tpnlContainer";
            this.tpnlContainer.RowCount = 4;
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tpnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tpnlContainer.Size = new System.Drawing.Size(557, 196);
            this.tpnlContainer.TabIndex = 2;
            // 
            // CustomerSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpnlContainer);
            this.Name = "CustomerSummary";
            this.Size = new System.Drawing.Size(557, 196);
            this.tpnlContainer.ResumeLayout(false);
            this.tpnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.TableLayoutPanel tpnlContainer;
    }
}
