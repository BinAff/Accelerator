namespace AutoTourism.Configuration
{
    partial class Building
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
            this.cboBuildingList = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bttnAddContact = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstFloorList = new System.Windows.Forms.ListBox();
            this.cboFloor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBuildingList
            // 
            this.cboBuildingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboBuildingList.FormattingEnabled = true;
            this.cboBuildingList.Location = new System.Drawing.Point(8, 40);
            this.cboBuildingList.Name = "cboBuildingList";
            this.cboBuildingList.Size = new System.Drawing.Size(174, 241);
            this.cboBuildingList.TabIndex = 1;
            this.cboBuildingList.SelectedIndexChanged += new System.EventHandler(this.cboBuildingList_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(261, 40);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(193, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(261, 66);
            this.txtFloor.MaxLength = 3;
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(40, 20);
            this.txtFloor.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Floor";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(261, 154);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(164, 21);
            this.cboType.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Type";
            // 
            // bttnAddContact
            // 
            this.bttnAddContact.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddContact.Location = new System.Drawing.Point(318, 65);
            this.bttnAddContact.Name = "bttnAddContact";
            this.bttnAddContact.Size = new System.Drawing.Size(32, 22);
            this.bttnAddContact.TabIndex = 74;
            this.bttnAddContact.Text = "  ►";
            this.bttnAddContact.UseVisualStyleBackColor = true;
            this.bttnAddContact.Click += new System.EventHandler(this.bttnAddContact_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(318, 93);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 22);
            this.btnRemove.TabIndex = 75;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstFloorList
            // 
            this.lstFloorList.FormattingEnabled = true;
            this.lstFloorList.Location = new System.Drawing.Point(356, 66);
            this.lstFloorList.Name = "lstFloorList";
            this.lstFloorList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFloorList.Size = new System.Drawing.Size(69, 82);
            this.lstFloorList.TabIndex = 76;
            // 
            // cboFloor
            // 
            this.cboFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFloor.FormattingEnabled = true;
            this.cboFloor.Location = new System.Drawing.Point(261, 181);
            this.cboFloor.Name = "cboFloor";
            this.cboFloor.Size = new System.Drawing.Size(61, 21);
            this.cboFloor.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Default Floor";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new System.Drawing.Point(261, 210);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(68, 17);
            this.chkDefault.TabIndex = 133;
            this.chkDefault.Text = "IsDefault";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // Building
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 287);
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.cboBuildingList);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cboFloor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstFloorList);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.bttnAddContact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFloor);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label6);
            this.Name = "Building";
            this.Text = "Building Configuration";
            this.Load += new System.EventHandler(this.Building_Load);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboType, 0);
            this.Controls.SetChildIndex(this.txtFloor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.bttnAddContact, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.lstFloorList, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboFloor, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.cboBuildingList, 0);
            this.Controls.SetChildIndex(this.chkDefault, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboBuildingList;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bttnAddContact;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstFloorList;
        private System.Windows.Forms.ComboBox cboFloor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chkDefault;
    }
}