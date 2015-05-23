﻿namespace Vanilla.Form.WinForm
{
	partial class Document
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
            this.pnlAttachment = new System.Windows.Forms.Panel();
            this.dgvAttachmentList = new System.Windows.Forms.DataGridView();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewLinkColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPickAncestor = new System.Windows.Forms.ToolStripButton();
            this.btnAddAncestor = new System.Windows.Forms.ToolStripButton();
            this.btnExpandCollapse = new System.Windows.Forms.ToolStripButton();
            this.btnAttach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.pnlAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttachment.Controls.Add(this.dgvAttachmentList);
            this.pnlAttachment.Location = new System.Drawing.Point(924, 565);
            this.pnlAttachment.Name = "pnlAttachment";
            this.pnlAttachment.Size = new System.Drawing.Size(26, 15);
            this.pnlAttachment.TabIndex = 7;
            this.pnlAttachment.Visible = false;
            // 
            // dgvAttachmentList
            // 
            this.dgvAttachmentList.AllowUserToAddRows = false;
            this.dgvAttachmentList.AllowUserToResizeRows = false;
            this.dgvAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.Action});
            this.dgvAttachmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachmentList.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachmentList.MultiSelect = false;
            this.dgvAttachmentList.Name = "dgvAttachmentList";
            this.dgvAttachmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachmentList.Size = new System.Drawing.Size(26, 15);
            this.dgvAttachmentList.TabIndex = 0;
            this.dgvAttachmentList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachmentList_CellContentDoubleClick);
            this.dgvAttachmentList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttachmentList_CellMouseClick);
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
            this.Action.FillWeight = 50F;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Delete";
            this.Action.ReadOnly = true;
            this.Action.Text = "Delete";
            this.Action.Width = 50;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnOk,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnPickAncestor,
            this.btnAddAncestor,
            this.btnExpandCollapse,
            this.btnAttach,
            this.toolStripSeparator3});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(962, 31);
            this.toolStrip.TabIndex = 100;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 28);
            this.btnRefresh.Text = "Q";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnRefresh.ToolTipText = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = false;
            this.btnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOk.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(28, 28);
            this.btnOk.Text = "ü";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOk.ToolTipText = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnPickAncestor
            // 
            this.btnPickAncestor.AutoSize = false;
            this.btnPickAncestor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPickAncestor.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnPickAncestor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPickAncestor.Name = "btnPickAncestor";
            this.btnPickAncestor.Size = new System.Drawing.Size(28, 28);
            this.btnPickAncestor.Text = "Ì";
            this.btnPickAncestor.ToolTipText = "Pick ";
            this.btnPickAncestor.Click += new System.EventHandler(this.btnPickAncestor_Click);
            // 
            // btnAddAncestor
            // 
            this.btnAddAncestor.AutoSize = false;
            this.btnAddAncestor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddAncestor.Font = new System.Drawing.Font("Wingdings 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAddAncestor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAncestor.Name = "btnAddAncestor";
            this.btnAddAncestor.Size = new System.Drawing.Size(28, 28);
            this.btnAddAncestor.Text = "Ç";
            this.btnAddAncestor.ToolTipText = "Add ";
            this.btnAddAncestor.Click += new System.EventHandler(this.btnAddAncestor_Click);
            // 
            // btnExpandCollapse
            // 
            this.btnExpandCollapse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExpandCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExpandCollapse.Enabled = false;
            this.btnExpandCollapse.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnExpandCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandCollapse.Name = "btnExpandCollapse";
            this.btnExpandCollapse.Size = new System.Drawing.Size(23, 28);
            this.btnExpandCollapse.Text = "×";
            this.btnExpandCollapse.ToolTipText = "Show Attachments";
            this.btnExpandCollapse.Click += new System.EventHandler(this.btnExpandCollapseAttachment_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAttach.AutoSize = false;
            this.btnAttach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAttach.Enabled = false;
            this.btnAttach.Font = new System.Drawing.Font("Webdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAttach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(28, 28);
            this.btnAttach.Text = "\'";
            this.btnAttach.ToolTipText = "Attach";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 28);
            this.btnDelete.Text = "û";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.ToolTipText = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 592);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pnlAttachment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Document";
            this.Text = "Forms";
            this.Controls.SetChildIndex(this.pnlAttachment, 0);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.pnlAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Panel pnlAttachment;
        private System.Windows.Forms.DataGridView dgvAttachmentList;
        protected System.Windows.Forms.ToolTip toolTip;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPickAncestor;
        private System.Windows.Forms.ToolStripButton btnAddAncestor;
        private System.Windows.Forms.ToolStripButton btnExpandCollapse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAttach;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewLinkColumn Action;
        private System.Windows.Forms.ToolStripButton btnDelete;

    }
}