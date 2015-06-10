namespace Vanilla.Form.WinForm
{
    partial class Container
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
            Vanilla.Utility.WinForm.SidePanel.Option option1 = new Vanilla.Utility.WinForm.SidePanel.Option();
            Vanilla.Utility.WinForm.SidePanel.Option option2 = new Vanilla.Utility.WinForm.SidePanel.Option();
            Vanilla.Utility.WinForm.SidePanel.Option option3 = new Vanilla.Utility.WinForm.SidePanel.Option();
            Vanilla.Utility.WinForm.SidePanel.Option option4 = new Vanilla.Utility.WinForm.SidePanel.Option();
            this.pnlTopActionRibbon = new System.Windows.Forms.Panel();
            this.pnlMenuSeperator2 = new System.Windows.Forms.Panel();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlMenuSeperator1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.spnlLeftLink = new Vanilla.Utility.WinForm.SidePanel();
            this.spnlRightLink = new Vanilla.Utility.WinForm.SidePanel();
            this.pnlAttachment = new System.Windows.Forms.Panel();
            this.dgvAttachmentList = new System.Windows.Forms.DataGridView();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pnlAttachmentHeading = new System.Windows.Forms.Panel();
            this.lblAttachmentHeading = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlTopActionRibbon.SuspendLayout();
            this.pnlAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).BeginInit();
            this.pnlAttachmentHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopActionRibbon
            // 
            this.pnlTopActionRibbon.Controls.Add(this.pnlMenuSeperator2);
            this.pnlTopActionRibbon.Controls.Add(this.btnSendEmail);
            this.pnlTopActionRibbon.Controls.Add(this.btnSendSMS);
            this.pnlTopActionRibbon.Controls.Add(this.btnDelete);
            this.pnlTopActionRibbon.Controls.Add(this.btnSave);
            this.pnlTopActionRibbon.Controls.Add(this.btnRefresh);
            this.pnlTopActionRibbon.Controls.Add(this.pnlMenuSeperator1);
            this.pnlTopActionRibbon.Controls.Add(this.btnSearch);
            this.pnlTopActionRibbon.Controls.Add(this.btnOpen);
            this.pnlTopActionRibbon.Controls.Add(this.btnNew);
            this.pnlTopActionRibbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopActionRibbon.Location = new System.Drawing.Point(0, 24);
            this.pnlTopActionRibbon.Name = "pnlTopActionRibbon";
            this.pnlTopActionRibbon.Size = new System.Drawing.Size(957, 50);
            this.pnlTopActionRibbon.TabIndex = 6;
            // 
            // pnlMenuSeperator2
            // 
            this.pnlMenuSeperator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuSeperator2.Location = new System.Drawing.Point(316, 0);
            this.pnlMenuSeperator2.Name = "pnlMenuSeperator2";
            this.pnlMenuSeperator2.Size = new System.Drawing.Size(16, 50);
            this.pnlMenuSeperator2.TabIndex = 6;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendEmail.Font = new System.Drawing.Font("Wingdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSendEmail.Location = new System.Drawing.Point(857, 0);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(50, 50);
            this.btnSendEmail.TabIndex = 10;
            this.btnSendEmail.Text = "*";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Visible = false;
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendSMS.Font = new System.Drawing.Font("Wingdings 3", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSendSMS.Location = new System.Drawing.Point(907, 0);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(50, 50);
            this.btnSendSMS.TabIndex = 9;
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Font = new System.Drawing.Font("Wingdings 2", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnDelete.Location = new System.Drawing.Point(266, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 50);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "O";
            this.toolTip.SetToolTip(this.btnDelete, "Cancel");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Font = new System.Drawing.Font("Wingdings 2", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSave.Location = new System.Drawing.Point(216, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "P";
            this.toolTip.SetToolTip(this.btnSave, "Save");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Font = new System.Drawing.Font("Wingdings 3", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRefresh.Location = new System.Drawing.Point(166, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 50);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Q";
            this.toolTip.SetToolTip(this.btnRefresh, "Reload");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlMenuSeperator1
            // 
            this.pnlMenuSeperator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuSeperator1.Location = new System.Drawing.Point(150, 0);
            this.pnlMenuSeperator1.Name = "pnlMenuSeperator1";
            this.pnlMenuSeperator1.Size = new System.Drawing.Size(16, 50);
            this.pnlMenuSeperator1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSearch.Location = new System.Drawing.Point(100, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 50);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "L";
            this.toolTip.SetToolTip(this.btnSearch, "Search (Advance) form");
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpen.Font = new System.Drawing.Font("Wingdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnOpen.Location = new System.Drawing.Point(50, 0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(50, 50);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "&&";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.btnOpen, "Open form");
            this.btnOpen.UseMnemonic = false;
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 50);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "";
            this.toolTip.SetToolTip(this.btnNew, "New form");
            this.btnNew.UseCompatibleTextRendering = true;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // spnlLeftLink
            // 
            this.spnlLeftLink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spnlLeftLink.ControlBarPosition = System.Windows.Forms.DockStyle.Top;
            this.spnlLeftLink.Dock = System.Windows.Forms.DockStyle.Left;
            this.spnlLeftLink.IsControlBarVisible = true;
            this.spnlLeftLink.Location = new System.Drawing.Point(0, 74);
            this.spnlLeftLink.Name = "spnlLeftLink";
            option1.Content = null;
            option1.Name = "Previous";
            option2.Content = null;
            option2.Name = "Next";
            this.spnlLeftLink.Options.Add(option1);
            this.spnlLeftLink.Options.Add(option2);
            this.spnlLeftLink.Size = new System.Drawing.Size(409, 330);
            this.spnlLeftLink.TabIndex = 9;
            this.spnlLeftLink.TitleBar = "Summary";
            // 
            // spnlRightLink
            // 
            this.spnlRightLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spnlRightLink.ControlBarPosition = System.Windows.Forms.DockStyle.Top;
            this.spnlRightLink.Dock = System.Windows.Forms.DockStyle.Right;
            this.spnlRightLink.IsControlBarVisible = false;
            this.spnlRightLink.Location = new System.Drawing.Point(797, 74);
            this.spnlRightLink.Name = "spnlRightLink";
            option3.Name = "Attachments";
            option4.Content = null;
            option4.Name = "Remarks";
            this.spnlRightLink.Options.Add(option3);
            this.spnlRightLink.Options.Add(option4);
            this.spnlRightLink.Size = new System.Drawing.Size(160, 330);
            this.spnlRightLink.TabIndex = 10;
            this.spnlRightLink.TitleBar = "Reference";
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.Controls.Add(this.dgvAttachmentList);
            this.pnlAttachment.Controls.Add(this.pnlAttachmentHeading);
            this.pnlAttachment.Location = new System.Drawing.Point(460, 190);
            this.pnlAttachment.Name = "pnlAttachment";
            this.pnlAttachment.Size = new System.Drawing.Size(223, 132);
            this.pnlAttachment.TabIndex = 13;
            this.pnlAttachment.Visible = false;
            // 
            // dgvAttachmentList
            // 
            this.dgvAttachmentList.AllowUserToAddRows = false;
            this.dgvAttachmentList.AllowUserToResizeRows = false;
            this.dgvAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.Delete});
            this.dgvAttachmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachmentList.Location = new System.Drawing.Point(0, 28);
            this.dgvAttachmentList.MultiSelect = false;
            this.dgvAttachmentList.Name = "dgvAttachmentList";
            this.dgvAttachmentList.ReadOnly = true;
            this.dgvAttachmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachmentList.Size = new System.Drawing.Size(223, 104);
            this.dgvAttachmentList.TabIndex = 12;
            this.dgvAttachmentList.Visible = false;
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Path.HeaderText = "Full Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 50F;
            this.Delete.HeaderText = "Action";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.Width = 50;
            // 
            // pnlAttachmentHeading
            // 
            this.pnlAttachmentHeading.Controls.Add(this.lblAttachmentHeading);
            this.pnlAttachmentHeading.Controls.Add(this.btnAttach);
            this.pnlAttachmentHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttachmentHeading.Location = new System.Drawing.Point(0, 0);
            this.pnlAttachmentHeading.Name = "pnlAttachmentHeading";
            this.pnlAttachmentHeading.Size = new System.Drawing.Size(223, 28);
            this.pnlAttachmentHeading.TabIndex = 15;
            // 
            // lblAttachmentHeading
            // 
            this.lblAttachmentHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAttachmentHeading.Location = new System.Drawing.Point(0, 0);
            this.lblAttachmentHeading.Name = "lblAttachmentHeading";
            this.lblAttachmentHeading.Size = new System.Drawing.Size(195, 28);
            this.lblAttachmentHeading.TabIndex = 13;
            this.lblAttachmentHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAttach
            // 
            this.btnAttach.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAttach.Font = new System.Drawing.Font("Webdings", 10F);
            this.btnAttach.Location = new System.Drawing.Point(195, 0);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(28, 28);
            this.btnAttach.TabIndex = 14;
            this.btnAttach.Text = "\'";
            this.toolTip.SetToolTip(this.btnAttach, "Attach");
            this.btnAttach.UseVisualStyleBackColor = true;
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 426);
            this.Controls.Add(this.pnlAttachment);
            this.Controls.Add(this.spnlRightLink);
            this.Controls.Add(this.spnlLeftLink);
            this.Controls.Add(this.pnlTopActionRibbon);
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Container";
            this.Load += new System.EventHandler(this.Container_Load);
            this.MdiChildActivate += new System.EventHandler(this.Container_MdiChildActivate);
            this.Shown += new System.EventHandler(this.Container_Shown);
            this.Controls.SetChildIndex(this.pnlTopActionRibbon, 0);
            this.Controls.SetChildIndex(this.spnlLeftLink, 0);
            this.Controls.SetChildIndex(this.spnlRightLink, 0);
            this.Controls.SetChildIndex(this.pnlAttachment, 0);
            this.pnlTopActionRibbon.ResumeLayout(false);
            this.pnlAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).EndInit();
            this.pnlAttachmentHeading.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopActionRibbon;
        private System.Windows.Forms.Panel pnlMenuSeperator2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlMenuSeperator1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolTip toolTip;
        private Utility.WinForm.SidePanel spnlLeftLink;
        private Utility.WinForm.SidePanel spnlRightLink;
        private System.Windows.Forms.Panel pnlAttachment;
        private System.Windows.Forms.DataGridView dgvAttachmentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Panel pnlAttachmentHeading;
        private System.Windows.Forms.Label lblAttachmentHeading;
        private System.Windows.Forms.Button btnAttach;

    }
}