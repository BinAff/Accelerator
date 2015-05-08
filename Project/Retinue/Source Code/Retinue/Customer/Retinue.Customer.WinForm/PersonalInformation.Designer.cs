namespace Retinue.Customer.WinForm
{
    partial class PersonalInformation
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
            this.lblIdProofTypeName = new System.Windows.Forms.Label();
            this.menuItemRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdentityProofNo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdProofTypeName
            // 
            this.lblIdProofTypeName.AutoSize = true;
            this.lblIdProofTypeName.Location = new System.Drawing.Point(-3, 220);
            this.lblIdProofTypeName.Name = "lblIdProofTypeName";
            this.lblIdProofTypeName.Size = new System.Drawing.Size(69, 13);
            this.lblIdProofTypeName.TabIndex = 118;
            this.lblIdProofTypeName.Text = "Identity Proof";
            // 
            // menuItemRegister
            // 
            this.menuItemRegister.Name = "menuItemRegister";
            this.menuItemRegister.Size = new System.Drawing.Size(114, 22);
            this.menuItemRegister.Text = "Register";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // menuItemBook
            // 
            this.menuItemBook.Name = "menuItemBook";
            this.menuItemBook.Size = new System.Drawing.Size(114, 22);
            this.menuItemBook.Text = "Book";
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(114, 22);
            this.menuItemDelete.Text = "Delete";
            // 
            // menuItemUpdate
            // 
            this.menuItemUpdate.Name = "menuItemUpdate";
            this.menuItemUpdate.Size = new System.Drawing.Size(114, 22);
            this.menuItemUpdate.Text = "Update";
            // 
            // menuItemView
            // 
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(114, 22);
            this.menuItemView.Text = "View";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemView,
            this.menuItemUpdate,
            this.menuItemDelete,
            this.menuItemBook,
            this.toolStripSeparator1,
            this.menuItemRegister});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(115, 120);
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.SystemColors.Control;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(100, 142);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(250, 43);
            this.lstContact.TabIndex = 117;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Contact Numbers";
            // 
            // txtIdentityProofNo
            // 
            this.txtIdentityProofNo.Location = new System.Drawing.Point(100, 217);
            this.txtIdentityProofNo.Name = "txtIdentityProofNo";
            this.txtIdentityProofNo.ReadOnly = true;
            this.txtIdentityProofNo.Size = new System.Drawing.Size(250, 20);
            this.txtIdentityProofNo.TabIndex = 113;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 191);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 112;
            // 
            // txtAdds
            // 
            this.txtAdds.Location = new System.Drawing.Point(100, 26);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.ReadOnly = true;
            this.txtAdds.Size = new System.Drawing.Size(250, 110);
            this.txtAdds.TabIndex = 109;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "EMail";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(-3, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 107;
            this.lblName.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Address";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 0);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(250, 20);
            this.txtName.TabIndex = 108;
            // 
            // PersonalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIdProofTypeName);
            this.Controls.Add(this.lstContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIdentityProofNo);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAdds);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "PersonalInformation";
            this.Size = new System.Drawing.Size(353, 240);
            this.Load += new System.EventHandler(this.PersonalInformation_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdProofTypeName;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemBook;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdentityProofNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
    }
}