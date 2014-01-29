namespace AutoTourism.Customer.WinForm
{
    partial class CustomerRegister
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
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.tbpOtherInfo = new System.Windows.Forms.TabPage();
            this.tbcCustomer = new System.Windows.Forms.TabControl();
            this.tbpPersonalInfo = new System.Windows.Forms.TabPage();
            this.lblIdProofTypeName = new System.Windows.Forms.Label();
            this.lstContact = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdentityProofNo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdds = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbcCustomer.SuspendLayout();
            this.tbpPersonalInfo.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.Lavender;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(11, 40);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(154, 247);
            this.cboCustomer.Sorted = true;
            this.cboCustomer.TabIndex = 41;
            this.cboCustomer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboCustomer_MouseClick);
            this.cboCustomer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cboCustomer_MouseDoubleClick);
            this.cboCustomer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cboContact_MouseDown);
            // 
            // tbpOtherInfo
            // 
            this.tbpOtherInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tbpOtherInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpOtherInfo.Name = "tbpOtherInfo";
            this.tbpOtherInfo.Size = new System.Drawing.Size(467, 221);
            this.tbpOtherInfo.TabIndex = 2;
            this.tbpOtherInfo.Text = "Other Information";
            // 
            // tbcCustomer
            // 
            this.tbcCustomer.Controls.Add(this.tbpPersonalInfo);
            this.tbcCustomer.Controls.Add(this.tbpOtherInfo);
            this.tbcCustomer.Location = new System.Drawing.Point(171, 40);
            this.tbcCustomer.Name = "tbcCustomer";
            this.tbcCustomer.SelectedIndex = 0;
            this.tbcCustomer.Size = new System.Drawing.Size(475, 247);
            this.tbcCustomer.TabIndex = 45;
            // 
            // tbpPersonalInfo
            // 
            this.tbpPersonalInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tbpPersonalInfo.Controls.Add(this.lblIdProofTypeName);
            this.tbpPersonalInfo.Controls.Add(this.lstContact);
            this.tbpPersonalInfo.Controls.Add(this.label5);
            this.tbpPersonalInfo.Controls.Add(this.txtIdentityProofNo);
            this.tbpPersonalInfo.Controls.Add(this.txtEmail);
            this.tbpPersonalInfo.Controls.Add(this.label7);
            this.tbpPersonalInfo.Controls.Add(this.label1);
            this.tbpPersonalInfo.Controls.Add(this.txtAdds);
            this.tbpPersonalInfo.Controls.Add(this.txtName);
            this.tbpPersonalInfo.Controls.Add(this.lblName);
            this.tbpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpPersonalInfo.Name = "tbpPersonalInfo";
            this.tbpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPersonalInfo.Size = new System.Drawing.Size(467, 221);
            this.tbpPersonalInfo.TabIndex = 0;
            this.tbpPersonalInfo.Text = "Personal Information";
            // 
            // lblIdProofTypeName
            // 
            this.lblIdProofTypeName.AutoSize = true;
            this.lblIdProofTypeName.Enabled = false;
            this.lblIdProofTypeName.Location = new System.Drawing.Point(3, 190);
            this.lblIdProofTypeName.Name = "lblIdProofTypeName";
            this.lblIdProofTypeName.Size = new System.Drawing.Size(0, 13);
            this.lblIdProofTypeName.TabIndex = 80;
            // 
            // lstContact
            // 
            this.lstContact.BackColor = System.Drawing.Color.Lavender;
            this.lstContact.Enabled = false;
            this.lstContact.FormattingEnabled = true;
            this.lstContact.Location = new System.Drawing.Point(126, 112);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(168, 43);
            this.lstContact.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(3, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Contact Numbers";
            // 
            // txtIdentityProofNo
            // 
            this.txtIdentityProofNo.BackColor = System.Drawing.Color.Lavender;
            this.txtIdentityProofNo.Enabled = false;
            this.txtIdentityProofNo.Location = new System.Drawing.Point(126, 187);
            this.txtIdentityProofNo.Name = "txtIdentityProofNo";
            this.txtIdentityProofNo.Size = new System.Drawing.Size(168, 20);
            this.txtIdentityProofNo.TabIndex = 38;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Lavender;
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(126, 161);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(4, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "EMail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Address";
            // 
            // txtAdds
            // 
            this.txtAdds.BackColor = System.Drawing.Color.Lavender;
            this.txtAdds.Enabled = false;
            this.txtAdds.Location = new System.Drawing.Point(126, 33);
            this.txtAdds.Multiline = true;
            this.txtAdds.Name = "txtAdds";
            this.txtAdds.Size = new System.Drawing.Size(168, 73);
            this.txtAdds.TabIndex = 23;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Lavender;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(126, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(335, 20);
            this.txtName.TabIndex = 20;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(4, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Name";
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(658, 197);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(41, 40);
            this.btnBook.TabIndex = 46;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
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
            this.contextMenu.Size = new System.Drawing.Size(117, 120);
            // 
            // menuItemView
            // 
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(116, 22);
            this.menuItemView.Text = "View";
            this.menuItemView.Click += new System.EventHandler(this.menuItemView_Click);
            // 
            // menuItemUpdate
            // 
            this.menuItemUpdate.Name = "menuItemUpdate";
            this.menuItemUpdate.Size = new System.Drawing.Size(116, 22);
            this.menuItemUpdate.Text = "Update";
            this.menuItemUpdate.Click += new System.EventHandler(this.menuItemUpdate_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(116, 22);
            this.menuItemDelete.Text = "Delete";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItemBook
            // 
            this.menuItemBook.Name = "menuItemBook";
            this.menuItemBook.Size = new System.Drawing.Size(116, 22);
            this.menuItemBook.Text = "Book";
            this.menuItemBook.Click += new System.EventHandler(this.menuItemBook_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // menuItemRegister
            // 
            this.menuItemRegister.Name = "menuItemRegister";
            this.menuItemRegister.Size = new System.Drawing.Size(116, 22);
            this.menuItemRegister.Text = "Register";
            this.menuItemRegister.Click += new System.EventHandler(this.menuItemRegister_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(171, 11);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(152, 23);
            this.btnSelect.TabIndex = 47;
            this.btnSelect.Text = "Select And Close";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // CustomerRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 298);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.tbcCustomer);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.btnBook);
            this.Name = "CustomerRegister";
            this.Text = "Customer Register";
            this.Load += new System.EventHandler(this.CustomerRegister_Load);
            this.tbcCustomer.ResumeLayout(false);
            this.tbpPersonalInfo.ResumeLayout(false);
            this.tbpPersonalInfo.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.TabPage tbpOtherInfo;
        private System.Windows.Forms.TabControl tbcCustomer;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.TabPage tbpPersonalInfo;
        private System.Windows.Forms.ListBox lstContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdentityProofNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdds;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemBook;
        private System.Windows.Forms.Label lblIdProofTypeName;
        private System.Windows.Forms.Button btnSelect;
    }
}